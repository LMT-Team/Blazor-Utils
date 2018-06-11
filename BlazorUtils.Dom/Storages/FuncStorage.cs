using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Blazor;
using static BlazorUtils.Dom.DomUtil;
// ReSharper disable InconsistentNaming
// ReSharper disable UnusedMember.Global

namespace BlazorUtils.Dom.Storages
{
    /// <summary>
    /// event callback
    /// </summary>
    public static class UICallBacksStorage
    {
        private static Dictionary<string, Action<UIEventArgs>> _actionStorage;
        private static Dictionary<string, string> _selectorStorage;
        private static Dictionary<string, string> _eventStorage;

        public static void Invoke(string id)
        {
            string value;

            if (_eventStorage[id] == "change")
            {
                value = _(_selectorStorage[id]).Val();
                _actionStorage[id].Invoke(new UIChangeEventArgs { Value = value });
            }
            else if (_eventStorage[id] == "click")
            {
                _actionStorage[id].Invoke(null);
            }
        }

        public static string Add(string events, string selector, Action<UIEventArgs> action)
        {
            if (_actionStorage == null)
            {
                _actionStorage = new Dictionary<string, Action<UIEventArgs>>();
                _selectorStorage = new Dictionary<string, string>();
                _eventStorage = new Dictionary<string, string>();
            }

            var id = Guid.NewGuid().ToString();
            _actionStorage.Add(id, action);
            _selectorStorage.Add(id, selector);
            _eventStorage.Add(id, events);
            return id;
        }
    }

    /// <summary>
    /// int-string-string callback
    /// </summary>
    public static class EnumerableCallBacksStorage
    {
        private static Dictionary<string, Func<int, string, string>> _funcStorage;

        public static string Invoke(string id, string index, string className)
        {
            return _funcStorage[id].Invoke(int.Parse(index), className);
        }

        public static string Add(Func<int, string, string> function)
        {
            if (_funcStorage == null)
            {
                _funcStorage = new Dictionary<string, Func<int, string, string>>();
            }

            var id = Guid.NewGuid().ToString();
            _funcStorage.Add(id, function);
            return id;
        }
    }

    /// <summary>
    /// int-int-double callback
    /// </summary>
    public static class EnumerableCallBacks3Storage
    {
        private static Dictionary<string, Func<int, int, double>> _funcStorage;

        public static string Invoke(string id, string index, string value)
        {
            return _funcStorage[id].Invoke(int.Parse(index), int.Parse(value)).ToString();
        }

        public static string Add(Func<int, int, double> function)
        {
            if (_funcStorage == null)
            {
                _funcStorage = new Dictionary<string, Func<int, int, double>>();
            }

            var id = Guid.NewGuid().ToString();
            _funcStorage.Add(id, function);
            return id;
        }
    }

    /// <summary>
    /// int-int-string callback
    /// </summary>
    public static class EnumerableCallBacks4Storage
    {
        private static Dictionary<string, Func<int, int, string>> _funcStorage;

        public static string Invoke(string id, string index, string value)
        {
            return _funcStorage[id].Invoke(int.Parse(index), int.Parse(value));
        }

        public static string Add(Func<int, int, string> function)
        {
            if (_funcStorage == null)
            {
                _funcStorage = new Dictionary<string, Func<int, int, string>>();
            }

            var id = Guid.NewGuid().ToString();
            _funcStorage.Add(id, function);
            return id;
        }
    }
}
