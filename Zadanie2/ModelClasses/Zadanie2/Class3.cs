using Newtonsoft.Json;
using System;
using System.Runtime.Serialization;

namespace ModelClasses.Zadanie2
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
            Class1 = (Class1)info.GetValue("Class1", typeof(Class1));
            Class2 = (Class2)info.GetValue("Class2", typeof(Class2));
            Text = (string)info.GetValue("Text", typeof(string));
            DateTime = (DateTime)info.GetValue("DateTime", typeof(DateTime));
            Number = (double)info.GetValue("Number", typeof(double));
        }
        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("Class1", Class1);
            info.AddValue("Class2", Class2);
            info.AddValue("Text", Text);
            info.AddValue("DateTime", DateTime);
            info.AddValue("Number", Number);
        }

        public override string ToString()
        {
            return " \"Class3\": { Class1: " + (Class1 == null ? "null" : "Exists") + ", Class2: " + (Class2 == null ? "null" : "Exists") + ", Text: " + Text + ", DateTime: " + DateTime + ", Number: " + Number + " }";
        }
    }
}
