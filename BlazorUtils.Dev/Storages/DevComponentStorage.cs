using System.Collections.Generic;

namespace BlazorUtils.Dev.Storages
{
    internal static class DevComponentStorage
    {
        private static HashSet<DevComponent> _internalDevComponents;

        private static HashSet<DevComponent> _devComponents
        {
            get
            {
                if (_internalDevComponents == null)
                {
                    _internalDevComponents = new HashSet<DevComponent>();
                }
                return _internalDevComponents;
            }
        }

        internal static void Add(DevComponent component)
        {
            _devComponents.Add(component);
        }

        internal static HashSet<DevComponent> GetAll()
        {
            return _devComponents;
        }
    }
}
