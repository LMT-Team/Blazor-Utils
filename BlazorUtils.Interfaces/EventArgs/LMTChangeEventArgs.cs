using System;
using System.Collections.Generic;
using System.Text;

namespace BlazorUtils.Interfaces.EventArgs
{
    public sealed class LMTChangeEventArgs : LMTEventArgs
    {
        public LMTChangeEventArgs(object value)
        {
            Value = value;
        }

        public object Value { get; set; }
    }
}
