using BlazorUtils.Interfaces;
using System.Collections.Generic;

namespace BlazorUtils.Dom.Storages
{
    internal static class DomPool
    {
        private static Dictionary<string, IDom> _domStorage;

        internal static IDom GetDom(string selector)
        {
            if (_domStorage.ContainsKey(selector)) return _domStorage[selector];
            var newDom = new Dom(selector);
            _domStorage.Add(selector, newDom);
            return newDom;
        }
    }
}
