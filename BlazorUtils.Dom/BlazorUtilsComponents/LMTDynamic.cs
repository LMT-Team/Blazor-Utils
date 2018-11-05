#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
using Microsoft.AspNetCore.Blazor;
using Microsoft.AspNetCore.Blazor.Components;
using Microsoft.AspNetCore.Blazor.RenderTree;

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
            var seq = 0;

            //Open component
            builder.OpenComponent<TComponent>(seq++);

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
