using System;
using System.Collections.Generic;
using System.Text;

namespace BlazorUtils.Interfaces.EventArgs
{
    /// <summary>
    /// Event argument for page changing. This class contains values applied BEFORE page changing.
    /// </summary>
    public sealed class PageChangedEventArgs : LMTEventArgs
    {
        public int Cur { get; }
        public int Next { get;  }
        public int Total { get; }
        public int Show { get; }
        public string PreviousText { get; }
        public string NextText { get; }
        public string FirstText { get; }
        public string LastText { get; }

        public PageChangedEventArgs(int cur, int next, int total, int show, string previousText, string nextText, string firstText, string lastText)
        {
            Cur = cur;
            Next = next;
            Total = total;
            Show = show;
            PreviousText = previousText;
            NextText = nextText;
            FirstText = firstText;
            LastText = lastText;
        }
    }
}
