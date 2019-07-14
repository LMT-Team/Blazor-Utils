using Microsoft.AspNetCore.Components;
using System.Collections.Generic;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using static BlazorUtils.Dom.DomUtils;

namespace BlazorUtils.Dev
{
    /// <summary>
    /// Providing dev tool for easier developing.
    /// </summary>
    public static partial class Dev
    {
        internal static bool _isLooped = false;
        internal static Dictionary<string, object> _objects = null;

        /// <summary>
        /// Map C# referance type instance to Js object with custom name.
        /// </summary>
        /// <param name="context">Component that contains the object, mostly 'this' keyword.</param>
        /// <param name="o">Reference type object</param>
        /// <param name="name">Js variable name</param>
        public static async Task MapAsync(ComponentBase context, object o, string name, [CallerFilePath] string filePath = null, [CallerLineNumber] int lineNumber = 0)
        {
            if (!(context is DevComponent)) return;

            //Add DevBoot Js code
            await DevUtils.DevBootAsync();

            AddToOrUpdateObjectList(o, name);
            UpdateMappingLayer();

            await DevUtils.DevWarnAsync($"Mapped {o.GetType().FullName} object in {filePath} at line {lineNumber}.");
        }

        private static async void UpdateMappingLayer()
        {
            await UpdateMapping();
        }

        private static async Task UpdateMapping()
        {
            if (!_isLooped) _isLooped = true;
            else return;

            PropertyInfo[] properties;
            FieldInfo[] fields;

            do
            {
                try
                {
                    foreach (var o in _objects)
                    {
                        await EvalAsync($"window.{o.Key} = {{}}");

                        properties = o.Value.GetType().GetProperties(BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance | BindingFlags.Static);
                        fields = o.Value.GetType().GetFields(BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance | BindingFlags.Static);

                        foreach (var property in properties)
                        {
                            var value = property.GetValue(o.Value);

                            if (value == null)
                            {
                                await EvalAsync($"{o.Key}.{property.Name} = {{value: null}}");
                                //Map set method to Js
                                await MapSetMethods(o, property);
                                continue;
                            }

                            var convertedResult = DevUtils.AsConverted(value, property.PropertyType);

                            if (convertedResult.Item2 != DevUtils.TypeGroup.Others)
                            {
                                await EvalAsync($"{o.Key}.{property.Name} = {{value: {convertedResult.Item1.ToString().ToLower()}}}");
                            }

                            else await EvalAsync($"{o.Key}.{property.Name} = {{value: \"{convertedResult.Item1}\"}}");

                            //Map set method to Js
                            await MapSetMethods(o, property);
                        }

                        foreach (var field in fields)
                        {
                            //Skip backing field
                            if (field.Name[0] == '<') continue;

                            var value = field.GetValue(o.Value);

                            if (value == null)
                            {
                                await EvalAsync($"{o.Key}.{field.Name} = {{value: null}}");
                                //Map set method to Js
                                await MapSetMethods(o, field);
                                continue;
                            }

                            var convertedResult = DevUtils.AsConverted(value, field.FieldType);

                            if (convertedResult.Item2 != DevUtils.TypeGroup.Others)
                            {
                                await EvalAsync($"{o.Key}.{field.Name} = {{value: {convertedResult.Item1.ToString().ToLower()}}}");
                            }
                            else await EvalAsync($"{o.Key}.{field.Name} = {{value: \"{convertedResult.Item1}\"}}");

                            //Map set method to Js
                            await MapSetMethods(o, field);
                        }
                    }
                }
                catch
                {
                    //Skip bug
                }

                await Task.Delay(500);
            } while (true);
        }

        private static async Task MapSetMethods(KeyValuePair<string, object> o, PropertyInfo property)
        {
            await EvalAsync($"window.{o.Key}.{property.Name}.set = (value) => {{window.Dev.SetObjectPropertyValue(\"{o.Key}\", \"{property.Name}\", value)}}");
        }

        private static async Task MapSetMethods(KeyValuePair<string, object> o, FieldInfo field)
        {
            await EvalAsync($"window.{o.Key}.{field.Name}.set = (value) => {{window.Dev.SetObjectPropertyValue(\"{o.Key}\", \"{field.Name}\", value)}}");
        }

        private static void AddToOrUpdateObjectList(object o, string name)
        {
            if (_objects == null) _objects = new Dictionary<string, object>();
            if (_objects.ContainsKey(name))
                _objects[name] = o;
            else
                _objects.Add(name, o);
        }
    }
}
