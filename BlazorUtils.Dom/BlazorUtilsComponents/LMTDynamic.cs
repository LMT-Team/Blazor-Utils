﻿using BlazorUtils.Interfaces.BlazorComponents;
using Microsoft.AspNetCore.Blazor;
using Microsoft.AspNetCore.Blazor.Components;
using Microsoft.AspNetCore.Blazor.RenderTree;
using System;

namespace BlazorUtils.Dom.BlazorUtilsComponents
{
    /// <summary>
    /// Implement a component by specifying component type.
    /// </summary>
    /// <typeparam name="TComponent">Component type. LMTDynamic can work with component parameter as a replacement for this generics feature. In that case, choose LMTEmpty for TComponent.</typeparam>
    public class LMTDynamic<TComponent> : BlazorComponent, ILMTComponent where TComponent : IComponent
    {
        [Parameter]
        private (string PropertyName, object Value)[] parameters { get; set; }

        [Parameter]
        private RenderFragment ChildContent { get; set; }

        [Parameter]
        private Type component { get; set; }

        protected override void BuildRenderTree(RenderTreeBuilder builder)
        {
            var seq = 0;

            //Open component
            if (component == null)
                builder.OpenComponent<TComponent>(seq++);
            else
                builder.OpenComponent(seq++, component);

            //Set attribute
            for (var i = 0; i < parameters.Length; i++)
            {
                builder.AddAttribute(seq++, parameters[i].PropertyName, parameters[i].Value);
            }

            if (ChildContent != null)
            {
                builder.AddAttribute(seq, "ChildContent", ChildContent);
            }

            builder.CloseComponent();
        }
    }
}
