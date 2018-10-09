using System;

namespace BlazorUtils.Dev
{
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field, Inherited = false, AllowMultiple = true)]
    public sealed class DevMapAttribute : Attribute
    {
        internal string MapName { get; set; }

        public DevMapAttribute(string mapName)
        {
            MapName = mapName;
        }
    }
}
