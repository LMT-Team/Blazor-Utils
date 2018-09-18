using System;

namespace BlazorUtils.Interfaces.JsPrototypes
{
    public class File
    {
        public File(string type, int size, string name, DateTime lastModified)
        {
            Type = type;
            Size = size;
            Name = name;
            LastModified = lastModified;
        }

        public string Type { get; }
        public int Size { get; }
        public string Name { get; }
        public DateTime LastModified { get; }
    }
}
