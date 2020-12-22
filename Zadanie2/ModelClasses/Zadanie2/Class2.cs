using Newtonsoft.Json;
using System;
using System.Runtime.Serialization;

namespace ModelClasses.Zadanie2
{
    [Serializable]
    [JsonObject]
    public class Class2 : ISerializable
    {
        public Class1 Class1 { get; set; }
        public Class3 Class3 { get; set; }
        public string Text { get; set; }
        public DateTime DateTime { get; set; }
        public double Number { get; set; }
        public Class2() { }
        public Class2(string text, DateTime dateTime, double number)
        {
            Text = text;
            DateTime = dateTime;
            Number = number;
        }
        public Class2(SerializationInfo info, StreamingContext context)
        {
            Class1 = (Class1)info.GetValue("Class1", typeof(Class1));
            Class3 = (Class3)info.GetValue("Class3", typeof(Class3));
            Text = (string) info.GetValue("Text", typeof(string));
            DateTime = (DateTime)info.GetValue("DateTime", typeof(DateTime));
            Number = (double) info.GetValue("Number", typeof(double));
        }
        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("Class1", Class1);
            info.AddValue("Class3", Class3);
            info.AddValue("Text", Text);
            info.AddValue("DateTime", DateTime);
            info.AddValue("Number", Number);
        }

        public override string ToString()
        {
            return " \"Class2\": { Class1: " + (Class1 == null ? "null" : "Exists") + ", Class3: " + (Class3 == null ? "null" : "Exists") + ", Text: " + Text + ", DateTime: " + DateTime + ", Number: " + Number + " }";
        }

    }
}
