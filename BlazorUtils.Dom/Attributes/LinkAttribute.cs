using System;

namespace BlazorUtils.Dom.Attributes
{
    /// <summary>
    /// ButtonAttribute defines button's text/label for data provided to LMT Blazor components, such as LMTTable.
    /// </summary>
    [AttributeUsage(AttributeTargets.Property, Inherited = false, AllowMultiple = false)]
    public sealed class LinkAttribute : Attribute
    {
        /// <summary>
        /// Initialize button attribute.
        /// </summary>
        /// <param name="text">Text/label of the button.</param>
        public LinkAttribute(string text)
        {
            Text = text;
        }

        /// <summary>
        /// Initialize button attribute.
        /// </summary>
        /// <param name="text">Text/label of the button.</param>
        /// <param name="target">Equivalent to HTML target attribute.</param>
        public LinkAttribute(string text, string target)
        {
            Text = text;
            Target = target;
        }

        internal string Text { get; set; }
        internal string Target { get; set; }

    }
}
