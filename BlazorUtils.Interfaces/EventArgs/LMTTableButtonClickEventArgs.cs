namespace BlazorUtils.Interfaces.EventArgs
{
    public sealed class LMTTableButtonClickEventArgs : LMTEventArgs
    {
        public LMTTableButtonClickEventArgs(object value)
        {
            Value = value;
        }

        public object Value { get; set; }
    }
}
