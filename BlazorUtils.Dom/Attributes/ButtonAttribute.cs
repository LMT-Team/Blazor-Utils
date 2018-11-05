using System;

namespace BlazorUtils.Dom.Attributes
{
    /// <summary>
    /// ButtonAttribute defines button's text/label for data provided to LMT Blazor components, such as LMTTable.
    /// </summary>
    [AttributeUsage(AttributeTargets.Property, Inherited = false, AllowMultiple = false)]
    public sealed class ButtonAttribute : Attribute
    {
        /// <summary>
        /// Initialize button attribute.
        /// </summary>
        /// <param name="text">Text/label of the button.</param>
        public ButtonAttribute(string text)
        {
            Text = text;
        }

        public string Text { get; set; }

    }
}
