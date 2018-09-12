using System.Collections.Generic;
using System.Reflection;
using System.Threading.Tasks;
using static BlazorUtils.Dom.DomUtil;

namespace BlazorUtils.Dev
{
    /// <summary>
    /// Providing dev tool for easier developing.
    /// </summary>
    public static class Dev
    {
        private static bool _isLooped = false;
        private static Dictionary<string, object> _objects = null;

        /// <summary>
        /// Map C# instance to Js object with custom name.
        /// </summary>
        /// <param name="o">C# instance</param>
        /// <param name="name">Js variable name</param>
        public static void Map(object o, string name)
        {
            AddToOrUpdateObjectList(o, name);
            UpdateMappingLayer();
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
                foreach (var o in _objects)
                {
                    Eval($"window.{o.Key} = {{}}");

                    properties = o.Value.GetType().GetProperties(BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance | BindingFlags.Static);
                    fields = o.Value.GetType().GetFields(BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance | BindingFlags.Static);

                    foreach (var property in properties)
                    {
                        var value = property.GetValue(o.Value);

                        if (value == null)
                        {
                            Eval($"{o.Key}.{property.Name} = null");
                        }

                        else if (double.TryParse(value.ToString(), out var _))
                        {
                            Eval($"{o.Key}.{property.Name} = {value}");
                        }

                        else Eval($"{o.Key}.{property.Name} = \"{value}\"");
                    }

                    foreach (var field in fields)
                    {
                        //Skip backing field
                        if (field.Name[0] == '<') continue;

                        var value = field.GetValue(o.Value);

                        if (value == null)
                        {
                            Eval($"{o.Key}.{field.Name} = null");
                        }

                        else if (double.TryParse(value.ToString(), out var _))
                        {
                            Eval($"{o.Key}.{field.Name} = {value}");
                        }
                        else Eval($"{o.Key}.{field.Name} = \"{value}\"");
                    }
                }

                await Task.Delay(500);
            } while (true);
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
