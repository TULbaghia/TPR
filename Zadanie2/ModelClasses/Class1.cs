using Newtonsoft.Json;
using System;
using System.Runtime.Serialization;
using System.Security.Permissions;

namespace ModelClasses
{
    [Serializable]
    [JsonObject]
    public class Class1 : ISerializable
    {
        public Class2 Class2 { get; set; }
        public Class3 Class3 { get; set; }
        public string Text { get; set; }
        public DateTime DateTime{ get; set; }
        public double Number { get; set; }
        public Class1() { }
        public Class1(string text, DateTime dateTime, double number)
        {
            Text = text;
            DateTime = dateTime;
            Number = number;
        }
        public Class1(SerializationInfo info, StreamingContext context)
        {
            Class2 = (Class2)info.GetValue("Class2", typeof(Class2));
            Class3 = (Class3)info.GetValue("Class3", typeof(Class3));
            Text = (string)info.GetValue("Text", typeof(string));
            DateTime = DateTime.Parse((string)info.GetValue("DateTime", typeof(string)));
            Number = Double.Parse((string)info.GetValue("Number", typeof(string)));
        }
        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("Class2", Class2);
            info.AddValue("Class3", Class3);
            info.AddValue("Text", Text);
            info.AddValue("DateTime", DateTime);
            info.AddValue("Number", Number);
        }
    }
}
