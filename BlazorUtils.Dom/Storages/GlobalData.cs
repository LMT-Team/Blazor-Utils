using System;
using System.Collections.Generic;

namespace BlazorUtils.Dom.Storages
{
    /// <summary>
    /// Static class that contains values which can be accessed from many code locations.
    /// </summary>
    public sealed class GlobalData
    {
        private GlobalData()
        {
            if (_data == null)
            {
                _data = new Dictionary<string, object>();
            }
        }

        /// <summary>
        /// Represents strict mode status.
        /// </summary>
        public static bool IsStrict { get; private set; }

        private static HashSet<string> _parameters;
        private static GlobalData _globalData;
        private static Dictionary<string, object> _data;

        /// <summary>
        /// Get shared GlobalData
        /// </summary>
        internal static GlobalData Shared
        {
            get
            {
                if (_globalData == null)
                {
                    _globalData = new GlobalData();
                }
                return _globalData;
            }
        }

        public object this[string key]
        {
            get
            {
                return _data[key];
            }
            set
            {
                if (IsStrict)
                {
                    if (_parameters == null || !_parameters.Contains(key))
                    {
                        Console.WriteLine($"Dom: No GlobalData parameter with the same name ({key}) is found. Remember, you're in strict mode.");
                        return;
                    }
                }

                _data[key] = value;
            }
        }

        /// <summary>
        /// Set GlobalData to strict mode.
        /// </summary>
        /// <param name="parameters">parameters that define GlobalData</param>
        public void SetToStrict(params string[] parameters)
        {
            if (IsStrict)
            {
                var (FileName, LineNumber) = GetTraceInfo();

                Console.WriteLine($"Dom: Duplicate GlobalData strict setup in {FileName} at line {LineNumber}.");
                return;
            }

            if (parameters == null)
            {
                var (FileName, LineNumber) = GetTraceInfo();

                Console.WriteLine($"Dom: GlobalData's parameters must not be null in {FileName} at line {LineNumber}.");
                return;
            }

            IsStrict = true;

            _parameters = new HashSet<string>(parameters);

            //----------------------------------

            (string FileName, int LineNumber) GetTraceInfo()
            {
                var frame = new System.Diagnostics.StackTrace(1).GetFrame(0);
                return (frame.GetFileName(), frame.GetFileLineNumber());
            }
        }
    }
}
