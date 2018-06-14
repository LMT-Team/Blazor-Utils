using System;

namespace BlazorUtils.Interfaces.Cookie
{
    public sealed class Cookie
    {
        public string Key { get; }
        public string Value { get; }
        public int Expires { get; } = -1;
        public string Path { get; } = "/";

        public Cookie()
        {

        }

        public Cookie(string key, string value)
        {
            Key = key ?? throw new ArgumentNullException(nameof(key));
            Value = value ?? throw new ArgumentNullException(nameof(value));
        }

        public Cookie(string key, string value, int expires) : this(key, value)
        {
            Expires = expires;
        }

        public Cookie(string key, string value, string path) : this(key, value)
        {
            Path = path;
        }

        public Cookie(string key, string value, int expires, string path) : this(key, value, expires)
        {
            Expires = expires;
            Path = path;
        }
    }
}