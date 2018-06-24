using System;
using System.Collections.Generic;
using System.Text;

namespace BlazorUtils.Interfaces.EventArgs
{
    /// <summary>
    /// Event argument for image changing. All the values are applied right before the begin of changing animation.
    /// </summary>
    public sealed class ImageChangedEventArgs : LMTEventArgs
    {
        public ImageChangedEventArgs(int cur, int next, string curImgUrl, string nextImgUrl, double brightness, bool isPause)
        {
            Cur = cur;
            Next = next;
            CurImgUrl = curImgUrl;
            NextImgUrl = nextImgUrl;
            Brightness = brightness;
            IsPause = isPause;
        }

        public int Cur { get; }
        public int Next { get; }
        public string CurImgUrl { get; }
        public string NextImgUrl { get; }
        public double Brightness { get; }
        public bool IsPause { get; }
    }
}
