using BlazorUtils.Dev.Storages;
using Microsoft.AspNetCore.Components;
using System.Linq;

namespace BlazorUtils.Dev
{
    public abstract class DevComponent : ComponentBase
    {
        public DevComponent()
        {
            AddToStorage(this);

            MapProperties(this);
            MapFields(this);
        }

        internal static async void AddToStorage(DevComponent o)
        {
            DevComponentStorage.Add(o);
            await DevUtils.DevWarnAsync($"{o.GetType().FullName} is now a dev component");
        }

        internal static void MapProperties(ComponentBase o)
        {
            var mappedProperties = DevUtils
                .GetAllProperties(o)
                .Where(x => x.CustomAttributes.Any(y => y.AttributeType == typeof(DevMapAttribute)));

            foreach(var property in mappedProperties)
            {
                Dev.Map(o, property.GetValue(o), 
                    ((DevMapAttribute)property.GetCustomAttributes(typeof(DevMapAttribute), false)[0]).MapName);
            }
        }

        internal static void MapFields(ComponentBase o)
        {
            var mappedFields = DevUtils
                .GetAllFields(o)
                .Where(x => x.CustomAttributes.Any(y => y.AttributeType == typeof(DevMapAttribute)));

            foreach (var field in mappedFields)
            {
                Dev.Map(o, field.GetValue(o),
                    ((DevMapAttribute)field.GetCustomAttributes(typeof(DevMapAttribute), false)[0]).MapName);
            }
        }
    }
}
