using System.Collections.Generic;
using System.Reflection;
using System.Threading.Tasks;
using static BlazorUtils.Dom.DomUtil;

namespace BlazorUtils.Dev
{
    public static class Dev
    {
        private static bool _isLooped = false;
        private static Dictionary<string, object> _objects = null;

        public static async Task Map(object o, string name)
        {
            AddToOrUpdateObjectList(o, name);
            await UpdateMapping();
        }

        private static async Task UpdateMapping()
        {
            if (!_isLooped) _isLooped = true;
            else return;

            PropertyInfo[] properties;
            FieldInfo[] fields;

            while (true)
            {
                foreach(var o in _objects)
                {
                    Eval($"var {o.Key} = {{}}");

                    properties = o.Value.GetType().GetProperties();
                    fields = o.Value.GetType().GetFields();

                    foreach (var property in properties)
                    {
                        Eval($"{o.Key}.{property.Name} = \"{property.GetValue(o.Value)}\"");
                    }

                    foreach (var field in fields)
                    {
                        Eval($"{o.Key}.{field.Name} = \"{field.GetValue(o.Value)}\"");
                    }
                }

                await Task.Delay(1);
            }
        }

        private static void AddToOrUpdateObjectList(object o, string name)
        {
            if (_objects == null) _objects = new Dictionary<string, object>();
            if (_objects.ContainsKey(name))
                _objects[name] = o;
            _objects.Add(name, o);
        }
    }
}
