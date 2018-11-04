#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
using Microsoft.AspNetCore.Blazor;
using Microsoft.AspNetCore.Blazor.Components;
using Microsoft.AspNetCore.Blazor.RenderTree;
//using System;
//using System.Reflection;

namespace BlazorUtils.Dom.BlazorUtilsComponents
{
    public class LMTDynamic<TComponent> : BlazorComponent where TComponent : IComponent
    {
        [Parameter]
        private (string PropertyName, object Value)[] parameters { get; set; }

        [Parameter]
        private RenderFragment ChildContent { get; set; }

        protected override void BuildRenderTree(RenderTreeBuilder builder)
        {
            //Open component
            builder.OpenComponent<TComponent>(0);

            //Set attribute
            foreach (var (PropertyName, Value) in parameters)
            {
                //if (!property.CanWrite) continue;

                builder.AddAttribute(0, PropertyName, Value);
            }

            builder.CloseComponent();

            ////try
            ////{
            //Console.WriteLine("Get child property");

            //    Console.WriteLine($"Number of frames: {builder.GetFrames().Array.Length}");

            //    foreach (var frame in builder.GetFrames().Array)
            //    {
            //        if (frame.ElementName == null) continue;
            //        Console.WriteLine("Frame component type: ");
            //        Console.WriteLine(frame.ElementName);
            //    }
            //    //var childProperty = typeof(TComponent).GetProperty("ChildContent", BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance);

            //    foreach (var property in builder.GetFrames().Array[0].Component.GetType().GetProperties(BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance))
            //    {
            //        Console.WriteLine(property.Name);
            //    }

            //    foreach (var property in typeof(TComponent).GetProperties(BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance))
            //    {
            //        if (property.Name != "ChildContent") continue;

            //        property.SetValue(builder.GetFrames().Array[0].Component, ChildContent);
            //    }

            //    Console.WriteLine(builder.GetFrames().Array[0].Component.GetType());

            //    Console.WriteLine("End dynamic");
            ////}
            ////No ChildContent property
            ////catch (Exception e)
            ////{
            ////    throw e;
            ////}
        }
    }
}
