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
        public string text { get; set; } = "Wolololo";
        public bool boolean { get; set; } = true;
        public double number { get; set; } = 3.2d;

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
/*            info.AddValue("class4", class4);*/
            info.AddValue("text", text);
            info.AddValue("boolean", boolean);
            info.AddValue("number", number);
        }
    }
}
