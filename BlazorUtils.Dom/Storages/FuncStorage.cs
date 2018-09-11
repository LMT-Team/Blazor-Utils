using System;
using System.Collections.Generic;
using BlazorUtils.Interfaces;
using BlazorUtils.Interfaces.EventArgs;
using Microsoft.AspNetCore.Blazor;
using static BlazorUtils.Dom.DomUtil;
// ReSharper disable InconsistentNaming
// ReSharper disable UnusedMember.Global
// ReSharper disable SpecifyACultureInStringConversionExplicitly

namespace BlazorUtils.Dom.Storages
{
    /// <summary>
    /// event callback
    /// </summary>
    internal static class UICallBacksStorage
    {
        private static Dictionary<string, Action<LMTEventArgs>> _actionStorage;
        private static Dictionary<string, string> _selectorStorage;
        private static Dictionary<string, string> _eventStorage;

        private static string Invoke(string id)
        {
            string value;
            LMTEventArgs eventArgs = null;

            if (_eventStorage[id] == "change")
            {
                value = _(_selectorStorage[id]).Val();
                eventArgs = new LMTChangeEventArgs(value);
                _actionStorage[id].Invoke(eventArgs);
            }
            else if (_eventStorage[id] == "click")
            {
                eventArgs = new LMTEventArgs();
                _actionStorage[id].Invoke(eventArgs);
            }
            else
            {
                eventArgs = new LMTEventArgs();
                _actionStorage[id].Invoke(eventArgs);
            };

            return (eventArgs != null && eventArgs.IsPrevented ? true : false).ToString();
        }

        internal static string Add(string events, string selector, Action<LMTEventArgs> action)
        {
            if (_actionStorage == null)
            {
                _actionStorage = new Dictionary<string, Action<LMTEventArgs>>();
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
    internal static class IntStringStringStorage
    {
        private static Dictionary<string, Func<int, string, string>> _funcStorage;

        private static string Invoke(string id, string index, string className)
        {
            return _funcStorage[id].Invoke(int.Parse(index), className);
        }

        internal static string Add(Func<int, string, string> function)
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
    internal static class IntIntDoubleStorage
    {
        private static Dictionary<string, Func<int, int, double>> _funcStorage;

        private static string Invoke(string id, string index, string value)
        {
            return _funcStorage[id].Invoke(int.Parse(index), int.Parse(value)).ToString();
        }

        internal static string Add(Func<int, int, double> function)
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
    internal static class IntIntStringStorage
    {
        private static Dictionary<string, Func<int, int, string>> _funcStorage;

        private static string Invoke(string id, string index, string value)
        {
            return _funcStorage[id].Invoke(int.Parse(index), int.Parse(value));
        }

        internal static string Add(Func<int, int, string> function)
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

    /// <summary>
    /// int-double-string callback
    /// </summary>
    internal static class IntDoubleStringStorage
    {
        private static Dictionary<string, Func<int, double, string>> _funcStorage;

        private static string Invoke(string id, string index, string value)
        {
            return _funcStorage[id].Invoke(int.Parse(index), double.Parse(value));
        }

        internal static string Add(Func<int, double, string> function)
        {
            if (_funcStorage == null)
            {
                _funcStorage = new Dictionary<string, Func<int, double, string>>();
            }

            var id = Guid.NewGuid().ToString();
            _funcStorage.Add(id, function);
            return id;
        }
    }

    /// <summary>
    /// int-double-double callback
    /// </summary>
    internal static class IntDoubleDoubleStorage
    {
        private static Dictionary<string, Func<int, double, double>> _funcStorage;

        private static string Invoke(string id, string index, string value)
        {
            return _funcStorage[id].Invoke(int.Parse(index), double.Parse(value)).ToString();
        }

        internal static string Add(Func<int, double, double> function)
        {
            if (_funcStorage == null)
            {
                _funcStorage = new Dictionary<string, Func<int, double, double>>();
            }

            var id = Guid.NewGuid().ToString();
            _funcStorage.Add(id, function);
            return id;
        }
    }

    /// <summary>
    /// int-Coords-Coords callback
    /// </summary>
    internal static class IntCoordsCoordsStorage
    {
        private static Dictionary<string, Func<int, Coordinate, Coordinate>> _funcStorage;

        private static string Invoke(string id, string index, string top, string left)
        {
            var callbackRes = _funcStorage[id].Invoke(int.Parse(index), new Coordinate
            {
                Top = double.Parse(top),
                Left = double.Parse(left)
            });
            var formatString = "\"top\": {0}, \"left\": {1}";
            return "{" + string.Format(formatString, callbackRes.Top, callbackRes.Left) + "}";
        }

        internal static string Add(Func<int, Coordinate, Coordinate> function)
        {
            if (_funcStorage == null)
            {
                _funcStorage = new Dictionary<string, Func<int, Coordinate, Coordinate>>();
            }

            var id = Guid.NewGuid().ToString();
            _funcStorage.Add(id, function);
            return id;
        }
    }
}
