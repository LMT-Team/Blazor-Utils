using BlazorUtils.Interfaces;
using System.Collections.Generic;

namespace BlazorUtils.Dom.Storages
{
    internal static class DomPool
    {
        private static Dictionary<string, ISyncDom> _domStorage;

        internal static ISyncDom GetDom(string selector)
        {
            if (_domStorage == null)
            {
                _domStorage = new Dictionary<string, ISyncDom>();
                return AddDom(selector);
            }
            if (_domStorage.ContainsKey(selector)) return _domStorage[selector];
            return AddDom(selector);
        }

        private static ISyncDom AddDom(string selector)
        {
            var newDom = new SyncDom(selector);
            _domStorage.Add(selector, newDom);
            return newDom;
        }
    }
}
