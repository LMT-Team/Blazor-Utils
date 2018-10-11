using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static BlazorUtils.Interfaces.Invokers.JsInvoke;

namespace BlazorUtils.Cookie
{
    /// <summary>
    /// Providing all methods for managing cookies. Please note that this class's data may not be affected by changing cookies from the Js environment as it stores its' own for caching. Call Update() or UpdateAsync() in this case.
    /// </summary>
    public static class Cookies
    {
        private static Dictionary<string, Interfaces.Cookie.Cookie> _dict;

        private static async Task<Dictionary<string, Interfaces.Cookie.Cookie>> GetDictAsync()
        {
            if (_dict == null)
            {
                _dict = new Dictionary<string, Interfaces.Cookie.Cookie>();
                var strCookies = await InvokeAsync<string>("LMTCookies");
                foreach (var ele in strCookies.Split(';'))
                {
                    var equalIndex = ele.IndexOf('=');
                    if (equalIndex == -1) continue;
                    var keyValue = ele.Substring(0, equalIndex).Trim();
                    _dict.Add(keyValue, new Interfaces.Cookie.Cookie(
                        keyValue,
                        ele.Substring(equalIndex + 1),
                        -2));
                }
            }

            return _dict;
        }

        private static Dictionary<string, Interfaces.Cookie.Cookie> GetDict()
        {
            if (_dict == null)
            {
                _dict = new Dictionary<string, Interfaces.Cookie.Cookie>();
                var strCookies = Invoke<string>("LMTCookies");
                foreach (var ele in strCookies.Split(';'))
                {
                    var equalIndex = ele.IndexOf('=');
                    if (equalIndex == -1) continue;
                    var keyValue = ele.Substring(0, equalIndex).Trim();
                    _dict.Add(keyValue, new Interfaces.Cookie.Cookie(
                        keyValue,
                        ele.Substring(equalIndex + 1),
                        -2));
                }
            }

            return _dict;
        }

        /// <summary>
        /// Get cookie by key
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public static Interfaces.Cookie.Cookie Get(string key) => GetDict()[key];

        /// <summary>
        /// Get cookie by key
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public static async Task<Interfaces.Cookie.Cookie> GetAsync(string key) => (await GetDictAsync())[key];

        /// <summary>
        /// Set a new cookie. If day expires is 0, it will be a session cookie. Set it to minus value in order to remove.
        /// </summary>
        /// <param name="cookie">Object representing cookie</param>
        public static void Set(Interfaces.Cookie.Cookie cookie)
        {
            Invoke<object>("LMTCookiesAdd", cookie.Key, cookie.Value, cookie.Expires, cookie.Path);
            //Set null to force getter to reinitialize list of cookies
            _dict = null;
        }

        /// <summary>
        /// Set a new cookie. If day expires is 0, it will be a session cookie. Set it to minus value in order to remove.
        /// </summary>
        /// <param name="cookie">Object representing cookie</param>
        public static async Task SetAsync(Interfaces.Cookie.Cookie cookie)
        {
            await InvokeAsync<object>("LMTCookiesAdd", cookie.Key, cookie.Value, cookie.Expires, cookie.Path);
            //Set null to force getter to reinitialize list of cookies
            _dict = null;
        }

        /// <summary>
        /// Clear all cookies
        /// </summary>
        public static void Clear()
        {
            var cookies = GetDict();
            foreach (var ele in cookies)
            {
                Remove(ele.Key);
            }
        }

        /// <summary>
        /// Clear all cookies
        /// </summary>
        public static async Task ClearAsync()
        {
            var cookies = await GetDictAsync();
            foreach (var ele in cookies)
            {
                await RemoveAsync(ele.Key);
            }
        }

        /// <summary>
        /// Remove a specific cookie
        /// </summary>
        /// <param name="key"></param>
        public static void Remove(string key)
        {
            Invoke<object>("LMTCookiesAdd", key, "", -999, "/");
        }

        /// <summary>
        /// Remove a specific cookie
        /// </summary>
        /// <param name="key"></param>
        public static async Task RemoveAsync(string key)
        {
            await InvokeAsync<object>("LMTCookiesAdd", key, "", -999, "/");
        }

        /// <summary>
        /// Force Cookies to re-initialize its' cache data.
        /// </summary>
        public static void Update()
        {
            _dict = null;
            GetDict();
        }


        /// <summary>
        /// Force Cookies to re-initialize its' cache data.
        /// </summary>
        public static async Task UpdateAsync()
        {
            _dict = null;
            await GetDictAsync();
        }

        /// <summary>
        /// Get all the cookies. The data may be outdated since GetAll() queries from Cookies cache. Call Update() or UpdateAsync() first if cookies have been changed from Js recently.
        /// </summary>
        /// <returns>A collection of Cookie.</returns>
        public static IEnumerable<Interfaces.Cookie.Cookie> GetAll()
        {
            return GetDict().Select(x => x.Value);
        }

        /// <summary>
        /// Get all the cookies. The data may be outdated since GetAll() queries from Cookies cache. Call Update() or UpdateAsync() first if cookies have been changed from Js recently.
        /// </summary>
        /// <returns>A collection of Cookie.</returns>
        public static async Task<IEnumerable<Interfaces.Cookie.Cookie>> GetAllAsync()
        {
            return (await GetDictAsync()).Select(x => x.Value);
        }
    }
}

