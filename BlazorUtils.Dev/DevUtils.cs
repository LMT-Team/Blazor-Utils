using BlazorUtils.Dev.Properties;
using System;
using System.Reflection;
using System.Threading.Tasks;
using static BlazorUtils.Dom.DomUtils;

namespace BlazorUtils.Dev
{
    internal static class DevUtils
    {
        private static bool _isBooted = false;

        internal enum TypeGroup
        {
            Numerics,
            Boolean,
            Others
        }

        internal static (object, TypeGroup) AsConverted(object value, Type type)
        {
            var stringValue = value.ToString();

            if (type == typeof(int))
            {
                if (int.TryParse(stringValue, out var result))
                {
                    return (result, TypeGroup.Numerics);
                }

                throw new Exception("BlazorUtils.Dev: Type and value not match");
            }
            if (type == typeof(bool))
            {
                if (bool.TryParse(stringValue, out var result))
                {
                    return (result, TypeGroup.Boolean);
                }

                throw new Exception("BlazorUtils.Dev: Type and value not match");
            }
            else if (type == typeof(double))
            {
                if (double.TryParse(stringValue, out var result))
                {
                    return (result, TypeGroup.Numerics);
                }

                throw new Exception("BlazorUtils.Dev: Type and value not match");
            }
            else if (type == typeof(float))
            {
                if (float.TryParse(stringValue, out var result))
                {
                    return (result, TypeGroup.Numerics);
                }

                throw new Exception("BlazorUtils.Dev: Type and value not match");
            }
            else if (type == typeof(short))
            {
                if (short.TryParse(stringValue, out var result))
                {
                    return (result, TypeGroup.Numerics);
                }

                throw new Exception("BlazorUtils.Dev: Type and value not match");
            }
            else return (stringValue, TypeGroup.Others);
        }

        internal static async Task DevBoot()
        {
            if (_isBooted) return;
            await EvalAsync(Resources.LMTDevBoot);
            _isBooted = true;
        }

        internal static async Task DevWarn(string message) => await Dev.WarnAsync($"BlazorUtils.Dev: {message}");

        internal static async Task DevError(string message) => await Dev.ErrorAsync($"BlazorUtils.Dev: {message}");

        internal static void InvokeMethod(object o, string methodName, object[] parameters = null)
        {
            GetMatchMethodFromAll(o, methodName).Invoke(o, parameters ?? new object[] { });
        }

        internal static MethodInfo GetMatchMethodFromAll(object o, string methodName) => o.GetType().GetMethod(methodName, BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance | BindingFlags.Static);
    }
}
