using System;
using System.Linq;
using System.Reflection;

namespace BlazorUtils.Dev
{
    internal static class DevConsole
    {
        private static void Set(string name, string property, string value)
        {
            if (!Dev._objects.ContainsKey(name))
            {
                Console.WriteLine("BlazorUtils.Dev: Object name not found!");
                return;
            }

            if (property == null)
            {
                Console.WriteLine("BlazorUtils.Dev: Property (2nd parameter) cannot be null or undefined!");
                return;
            }

            var type = Dev._objects[name].GetType();

            var properties = type.GetProperties(BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance | BindingFlags.Static);

            var foundProperty = properties.FirstOrDefault(x => x.Name == property);

            if (foundProperty != null)
            {
                var convertResult = DevUtils.AsConverted(Dev._objects[name], foundProperty.GetType());
                foundProperty.SetValue(Dev._objects[name], convertResult.Item1);
                return;
            }

            var fields = type.GetFields(BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance | BindingFlags.Static);

            var foundField = fields.FirstOrDefault(x => x.Name == property);

            if (foundField != null)
            {
                var convertResult = DevUtils.AsConverted(Dev._objects[name], foundField.GetType());
                foundProperty.SetValue(Dev._objects[name], convertResult.Item1);
                return;
            }

            Console.WriteLine("No property of field found");
        }
    }
}
