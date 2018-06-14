using System;

namespace BlazorUtils.Interfaces.Cookie
{
    public sealed class Cookie
    {
        public string Key { get; }
        public string Value { get; }
        public int Expires { get; }
        public string Path { get; }

        public Cookie(string key, string value, int expires = 0, string path = "/")
        {
            Key = key ?? throw new ArgumentNullException(nameof(key));
            Value = value ?? throw new ArgumentNullException(nameof(value));
            Expires = expires;
            Path = path;
        }
    }
}