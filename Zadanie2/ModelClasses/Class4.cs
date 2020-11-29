using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace ModelClasses
{
    [Serializable]
    public class Class4 : ISerializable
    {
        public Class4 class4 { get; set; }
        public string Text { get; set; } = "Wolololo";
        public bool Boolean { get; set; } = true;
        public double Number { get; set; } = 3.2d;
        public Class4() { }
        public Class4(SerializationInfo info, StreamingContext context)
        {
            class4 = (Class4)info.GetValue("Class4", typeof(Class4));
            Text = (string)info.GetValue("Text", typeof(string));
            Boolean = (Boolean)info.GetValue("Boolean", typeof(Boolean));
            Number = (double)info.GetValue("Number", typeof(double));
        }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("Class4", class4);
            info.AddValue("Text", Text);
            info.AddValue("Boolean", Boolean);
            info.AddValue("Number", Number);
        }
    }
}
