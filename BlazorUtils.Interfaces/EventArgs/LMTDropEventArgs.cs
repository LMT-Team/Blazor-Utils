using System;
using System.IO;
using System.Linq;

namespace BlazorUtils.Interfaces.EventArgs
{
    public class LMTDropEventArgs : LMTEventArgs
    {
        private Stream _fileStream;
        private byte[] _dataByte;
        private string _base64String;
        
        public JsPrototypes.File File { get; }
        public string DataUrl { get; }

        public string Base64String
        {
            get
            {
                if (_base64String == null)
                {
                    _base64String = DataUrl.Substring(DataUrl.IndexOf("base64,") + 7);
                }
                return _base64String;
            }
        }

        public byte[] DataBytes
        {
            get
            {
                if (_dataByte == null)
                {
                    _dataByte = Convert.FromBase64String(Base64String).ToArray();
                }
                return _dataByte;
            }
        }

        public Stream FileStream
        {
            get
            {
                if (_fileStream == null)
                {
                    _fileStream = new MemoryStream(DataBytes.ToArray());
                }
                return _fileStream;
            }
        }

        public LMTDropEventArgs(string dataUrl, JsPrototypes.File file)
        {
            DataUrl = dataUrl;
            File = file;
        }
    }
}
