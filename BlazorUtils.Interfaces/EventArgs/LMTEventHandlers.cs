// ReSharper disable InconsistentNaming

namespace BlazorUtils.Interfaces.EventArgs
{
    public class LMTEventHandlers
    {
        public delegate void LMTEventHandler<in T>(T e);
    }
}
