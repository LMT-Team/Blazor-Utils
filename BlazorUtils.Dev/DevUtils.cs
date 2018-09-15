using System;

namespace BlazorUtils.Dev
{
    internal static class DevUtils
    {
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
    }
}
