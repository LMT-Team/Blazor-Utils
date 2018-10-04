using System.Threading.Tasks;
using static BlazorUtils.Interfaces.Invokers.JsInvoke;

namespace BlazorUtils.Cookie
{
    /// <summary>
    /// Session storage util class.
    /// </summary>
    public static class SessionStorage
    {
        /// <summary>
        /// Get storage by key.
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public static string Get(string key)
        {
            return Invoke<string>("SessionStorageGet", key);
        }

        /// <summary>
        /// Get storage by key.
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public static async Task<string> GetAsync(string key)
        {
            return await InvokeAsync<string>("SessionStorageGet", key);
        }

        /// <summary>
        /// Set storage with key and value.
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        public static void Set(string key, string value)
        {
            Invoke<object>("SessionStorageSet", key, value);
        }

        /// <summary>
        /// Set storage with key and value.
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        public static async Task SetAsync(string key, string value)
        {
            await InvokeAsync<object>("SessionStorageSet", key, value);
        }

        /// <summary>
        /// Remove storage data by key.
        /// </summary>
        /// <param name="key"></param>
        public static void Remove(string key)
        {
            Invoke<object>("SessionStorageRemove", key);
        }

        /// <summary>
        /// Remove storage data by key.
        /// </summary>
        /// <param name="key"></param>
        public static async Task RemoveAsync(string key)
        {
            await InvokeAsync<object>("SessionStorageRemove", key);
        }

        /// <summary>
        /// Clear all storage data.
        /// </summary>
        public static void Clear()
        {
            Invoke<object>("SessionStorageClear");
        }

        /// <summary>
        /// Clear all storage data.
        /// </summary>
        public static async Task ClearAsync()
        {
            await InvokeAsync<object>("SessionStorageClear");
        }
    }
}
