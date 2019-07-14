using BlazorUtils.Dev.Storages;
using Microsoft.AspNetCore.Components;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorUtils.Dev
{
    public abstract class DevComponent : ComponentBase
    {
        public DevComponent()
        {
            AddToStorage(this);
        }

        public async Task InitDevComponent()
        {
            await MapProperties(this);
            await MapFields(this);
            Console.WriteLine($"BlazorUtils.Dev: {GetType().FullName} has been initialized!");
        }

        internal static void AddToStorage(DevComponent o)
        {
            DevComponentStorage.Add(o);
            Console.WriteLine($"BlazorUtils.Dev: {o.GetType().FullName} is now a dev component but hasn't been initialized. Please call InitDevComponent().");
        }

        internal static async Task MapProperties(ComponentBase o)
        {
            var mappedProperties = DevUtils
                .GetAllProperties(o)
                .Where(x => x.CustomAttributes.Any(y => y.AttributeType == typeof(DevMapAttribute)));

            foreach(var property in mappedProperties)
            {
                await Dev.MapAsync(o, property.GetValue(o), 
                    ((DevMapAttribute)property.GetCustomAttributes(typeof(DevMapAttribute), false)[0]).MapName);
            }
        }

        internal async Task MapFields(ComponentBase o)
        {
            var mappedFields = DevUtils
                .GetAllFields(o)
                .Where(x => x.CustomAttributes.Any(y => y.AttributeType == typeof(DevMapAttribute)));

            foreach (var field in mappedFields)
            {
                await Dev.MapAsync(o, field.GetValue(o),
                    ((DevMapAttribute)field.GetCustomAttributes(typeof(DevMapAttribute), false)[0]).MapName);
            }
        }
    }
}
