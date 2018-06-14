using System;

namespace BlazorUtils.Interfaces.Cookie
{
    /// <summary>
    /// Object representing cookie
    /// </summary>
    public sealed class Cookie
    {
        /// <summary>
        /// Cookie key
        /// </summary>
        public string Key { get; }
        /// <summary>
        /// Cookie value
        /// </summary>
        public string Value { get; }
        /// <summary>
        /// Cookie expire days
        /// </summary>
        public int Expires { get; }
        /// <summary>
        /// Cookie path
        /// </summary>
        public string Path { get; }
        /// <summary>
        /// Initializing a cookie
        /// </summary>
        /// <param name="key">Cookie key</param>
        /// <param name="value">Cookie value</param>
        /// <param name="expires">Cookie expire days</param>
        /// <param name="path">Cookie path</param>
        public Cookie(string key, string value, int expires = 0, string path = "/")
        {
            Key = key ?? throw new ArgumentNullException(nameof(key));
            Value = value ?? throw new ArgumentNullException(nameof(value));
            Expires = expires;
            Path = path;
        }
    }
}