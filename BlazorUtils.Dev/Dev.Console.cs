using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using static BlazorUtils.Dev.DevUtils;
using static BlazorUtils.Dom.DomUtils;

namespace BlazorUtils.Dev
{
    public static partial class Dev
    {
        private static async void Set(string name, string property, string value)
        {
            if (!_objects.ContainsKey(name))
            {
                await DevErrorAsync("BlazorUtils.Dev: Object name not found!");
                return;
            }

            if (property == null)
            {
                await DevErrorAsync("BlazorUtils.Dev: Property (2nd parameter) cannot be null or undefined!");
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
                foundField.SetValue(_objects[name], convertResult.Item1);
                return;
            }

            await DevErrorAsync("No property or field found");
        }

        /// <summary>
        /// Write warning message to devtool console.
        /// </summary>
        /// <param name="message"></param>
        public static void Warn(object message) => Eval($"console.warn(\"{message}\")");

        /// <summary>
        /// Write warning message to devtool console.
        /// </summary>
        /// <param name="message"></param>
        public static async Task WarnAsync(object message) => await EvalAsync($"console.warn(\"{message}\")");

        /// <summary>
        /// Write error message to devtool console.
        /// </summary>
        /// <param name="message"></param>
        public static void Error(object message) => Eval($"console.error(\"{message}\")");

        /// <summary>
        /// Write error message to devtool console.
        /// </summary>
        /// <param name="message"></param>
        public static async Task ErrorAsync(object message) => await EvalAsync($"console.error(\"{message}\")");

        /// <summary>
        /// Write log to devtool console.
        /// </summary>
        /// <param name="message"></param>
        public static void Log(object message) => Eval($"console.log('{message}')");

        /// <summary>
        /// Write log to devtool console.
        /// </summary>
        /// <param name="message"></param>
        public static async Task LogAsync(object message) => await EvalAsync($"console.log('{message}')");
    }
}
