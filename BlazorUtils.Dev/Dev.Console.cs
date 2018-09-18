using System.Linq;
using System.Reflection;
using static BlazorUtils.Dev.DevUtils;
using static BlazorUtils.Dom.DomUtil;

namespace BlazorUtils.Dev
{
    public static partial class Dev
    {
        private static void Set(string name, string property, string value)
        {
            if (!_objects.ContainsKey(name))
            {
                DevError("BlazorUtils.Dev: Object name not found!");
                return;
            }

            if (property == null)
            {
                DevError("BlazorUtils.Dev: Property (2nd parameter) cannot be null or undefined!");
                return;
            }

            var type = _objects[name].GetType();

            var properties = type.GetProperties(BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance | BindingFlags.Static);

            var foundProperty = properties.FirstOrDefault(x => x.Name == property);

            if (foundProperty != null)
            {
                var convertResult = AsConverted(value, foundProperty.PropertyType);
                foundProperty.SetValue(_objects[name], convertResult.Item1);
                return;
            }

            var fields = type.GetFields(BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance | BindingFlags.Static);

            var foundField = fields.FirstOrDefault(x => x.Name == property);

            if (foundField != null)
            {
                var convertResult = AsConverted(value, foundField.FieldType);
                foundProperty.SetValue(_objects[name], convertResult.Item1);
                return;
            }

            DevError("No property of field found");
        }

        /// <summary>
        /// Write warning message to devtool console
        /// </summary>
        /// <param name="message"></param>
        public static void Warn(string message) => Eval($"console.warn(\"{message}\")");

        /// <summary>
        /// Write error message to devtool console
        /// </summary>
        /// <param name="message"></param>
        public static void Error(string message) => Eval($"console.error(\"{message}\")");
    }
}
