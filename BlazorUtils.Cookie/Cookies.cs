using System.Collections.Generic;
using static Microsoft.AspNetCore.Blazor.Browser.Interop.RegisteredFunction;

namespace BlazorUtils.Cookie
{
    /// <summary>
    /// Providing all methods for managing cookies
    /// </summary>
    public static class Cookies
    {
        private static Dictionary<string, Interfaces.Cookie.Cookie> _dict;

        private static Dictionary<string, Interfaces.Cookie.Cookie> Dict
        {
            get
            {
                if (_dict == null)
                {
                    _dict = new Dictionary<string, Interfaces.Cookie.Cookie>();
                    var strCookies = Invoke<string>("LMTCookies");
                    foreach (var ele in strCookies.Split(';'))
                    {
                        var keyValue = ele.Split('=');
                        _dict.Add(keyValue[0].Trim(), new Interfaces.Cookie.Cookie(keyValue[0].Trim(), keyValue[1].Trim(), -2));
                    }
                }

                return _dict;
            }
        }

        /// <summary>
        /// Get cookie by key
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public static Interfaces.Cookie.Cookie GetCookie(string key) => Dict[key];

        /// <summary>
        /// Set a new cookie. If day expires is 0, it will be a session cookie. Set it to minus value in order to remove.
        /// </summary>
        /// <param name="cookie">Object representing cookie</param>
        public static void SetCookie(Interfaces.Cookie.Cookie cookie)
        {
            Invoke<object>("LMTCookiesAdd", cookie.Key, cookie.Value, cookie.Expires, cookie.Path);
            //Set null to force getter to reinitialize list of cookies
            _dict = null;
        }

        /// <summary>
        /// Remove all cookies
        /// </summary>
        public static void RemoveAllCookies()
        {
            foreach(var ele in Dict)
            {
                Invoke<object>("LMTCookiesAdd", ele.Key, "", -999, "/");
            }
        }
    }
}

