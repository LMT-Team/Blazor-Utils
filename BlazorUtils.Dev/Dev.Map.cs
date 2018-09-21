﻿using System.Collections.Generic;
using System.Reflection;
using System.Threading.Tasks;
using static BlazorUtils.Dom.DomUtil;

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
        /// Map C# instance to Js object with custom name.
        /// </summary>
        /// <param name="o">C# instance</param>
        /// <param name="name">Js variable name</param>
        public static void Map(object o, string name)
        {
            //Add DevBoot Js code
            DevUtils.DevBoot();

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
                            Eval($"{o.Key}.{property.Name} = {{value: null}}");
                            //Map set method to Js
                            MapSetMethods(o, property);
                            continue;
                        }

                        var convertedResult = DevUtils.AsConverted(value, property.PropertyType);

                        if (convertedResult.Item2 != DevUtils.TypeGroup.Others)
                        {
                            Eval($"{o.Key}.{property.Name} = {{value: {convertedResult.Item1.ToString().ToLower()}}}");
                        }

                        else Eval($"{o.Key}.{property.Name} = {{value: \"{convertedResult.Item1}\"}}");

                        //Map set method to Js
                        MapSetMethods(o, property);
                    }

                    foreach (var field in fields)
                    {
                        //Skip backing field
                        if (field.Name[0] == '<') continue;

                        var value = field.GetValue(o.Value);

                        if (value == null)
                        {
                            Eval($"{o.Key}.{field.Name} = {{value: null}}");
                            //Map set method to Js
                            MapSetMethods(o, field);
                            continue;
                        }

                        var convertedResult = DevUtils.AsConverted(value, field.FieldType);

                        if (convertedResult.Item2 != DevUtils.TypeGroup.Others)
                        {
                            Eval($"{o.Key}.{field.Name} = {{value: {convertedResult.Item1.ToString().ToLower()}}}");
                        }
                        else Eval($"{o.Key}.{field.Name} = {{value: \"{convertedResult.Item1}\"}}");

                        //Map set method to Js
                        MapSetMethods(o, field);
                    }
                }

                await Task.Delay(500);
            } while (true);
        }

        private static void MapSetMethods(KeyValuePair<string, object> o, PropertyInfo property)
        {
            Eval($"window.{o.Key}.{property.Name}.set = (value) => {{window.Dev.SetObjectPropertyValue(\"{o.Key}\", \"{property.Name}\", value)}}");
        }

        private static void MapSetMethods(KeyValuePair<string, object> o, FieldInfo field)
        {
            Eval($"window.{o.Key}.{field.Name}.set = (value) => {{window.Dev.SetObjectPropertyValue(\"{o.Key}\", \"{field.Name}\", value)}}");
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