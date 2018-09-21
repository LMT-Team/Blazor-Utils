using static BlazorUtils.Interfaces.Invokers.JsInvoke;

namespace BlazorUtils.Cookie
{
    /// <summary>
    /// Local storage util class.
    /// </summary>
    public static class LocalStorage
    {
        /// <summary>
        /// Get storage by key.
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public static string Get(string key)
        {
            return Invoke<string>("LocalStorageGet", key);
        }

        /// <summary>
        /// Set storage with key and value.
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        public static void Set(string key, string value)
        {
            Invoke<object>("LocalStorageSet", key, value);
        }

        /// <summary>
        /// Remove storage data by key.
        /// </summary>
        /// <param name="key"></param>
        public static void Remove(string key)
        {
            Invoke<object>("LocalStorageRemove", key);
        }

        /// <summary>
        /// Clear all storage data.
        /// </summary>
        public static void Clear()
        {
            Invoke<object>("LocalStorageClear");
        }
    }
}
