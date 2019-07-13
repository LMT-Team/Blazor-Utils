using Microsoft.AspNetCore.Components;

namespace BlazorUtils.Interfaces.EventArgs
{
    public class LMTEventArgs : UIEventArgs
    {
        public bool IsPrevented { private set; get; }

        public void PreventDefault()
        {
            IsPrevented = true;
        }
    }
}
