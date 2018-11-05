using System;
using System.Collections.Generic;
using System.Text;
using static BlazorUtils.Dom.DomUtils;

namespace BlazorUtils.Dom.Attributes
{
    /// <summary>
    /// Attribute for header, used for components like LMTTable.
    /// </summary>
    public sealed class HeadAttribute : Attribute
    {
        /// <summary>
        /// Initialize attribute.
        /// </summary>
        /// <param name="text">Title of header.</param>
        public HeadAttribute(string text)
        {
            Text = text;
        }

        /// <summary>
        /// Initialize attribute.
        /// </summary>
        /// <param name="text">Title of header.</param>
        /// <param name="tagType">Type of tag surrounding values.</param>
        /// <param name="index">Index of header. Can be started with 0 or any numbers. Default is 0</param>
        public HeadAttribute(string text, TagType tagType, int index)
        {
            Text = text;
            TagType = tagType;
            Index = index;
        }

        /// <summary>
        /// Initialize attribute.
        /// </summary>
        /// <param name="text">Title of header.</param>
        /// <param name="tagType">Type of tag surrounding values.</param>
        public HeadAttribute(string text, TagType tagType)
        {
            Text = text;
            TagType = tagType;
        }

        /// <summary>
        /// Initialize attribute.
        /// </summary>
        /// <param name="text">Title of header.</param>
        /// <param name="index">Index of header. Can be started with 0 or any numbers. Default is 0</param>
        public HeadAttribute(string text, int index)
        {
            Text = text;
            Index = index;
        }

        public string Text { get; set; }
        public TagType TagType { get; set; } = TagType.none;
        public int Index { get; set; } = 0;
    }
}
