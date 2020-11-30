using Newtonsoft.Json;
using System;
using System.Runtime.Serialization;
using System.Security.Permissions;

namespace ModelClasses
{
    [Serializable]
    [JsonObject]
    public class Class3 : ISerializable
    {
        public Class1 Class1 { get; set; }
        public Class2 Class2 { get; set; }
        public string Text { get; set; }
        public DateTime DateTime { get; set; }
        public double Number { get; set; }
        public Class3() { }
        public Class3(string text, DateTime dateTime, double number)
        {
            Text = text;
            DateTime = dateTime;
            Number = number;
        }
        public Class3(SerializationInfo info, StreamingContext context)
        {
            Class1 = (Class1)info.GetValue("class1", typeof(Class1));
            Class2 = (Class2)info.GetValue("class2", typeof(Class2));
            Text = (string)info.GetValue("text", typeof(string));
            DateTime = DateTime.Parse((string)info.GetValue("DateTime", typeof(string)));
            Number = Double.Parse((string)info.GetValue("number", typeof(string)));
        }
        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("class1", Class1);
            info.AddValue("class2", Class2);
            info.AddValue("text", Text);
            info.AddValue("DateTime", DateTime);
            info.AddValue("number", Number);
        }

        public override string ToString()
        {
            return " \"Class3\": { Class1: " + (Class1 == null ? "null" : "Exists") + ", Class2: " + (Class2 == null ? "null" : "Exists") + ", Text: " + Text + ", DateTime: " + DateTime + ", Number: " + Number + " }";
        }
    }
}
