using System.Collections.Generic;
using static Microsoft.AspNetCore.Blazor.Browser.Interop.RegisteredFunction;

namespace BlazorUtils.Cookie
{
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
                        _dict.Add(keyValue[0], new Interfaces.Cookie.Cookie(keyValue[0], keyValue[1], -2));
                    }
                }

                return _dict;
            }
        }

        public static Interfaces.Cookie.Cookie GetCookie(string key) => Dict[key];

        public static void SetCookie(Interfaces.Cookie.Cookie cookie)
        {
            Invoke<object>("LMTCookiesAdd", cookie.Key, cookie.Value, cookie.Expires, cookie.Path);
            //Set null to force getter to reinitialize list of cookies
            _dict = null;
        }

        public static void RemoveAllCookies()
        {
            foreach(var ele in Dict)
            {
                Invoke<object>("LMTCookiesAdd", ele.Key, "", -999, "/");
            }
        }
    }
}

