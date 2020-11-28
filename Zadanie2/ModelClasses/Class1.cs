using System;

namespace ModelClasses
{
    public class Class1
    {
        private Class2 Class2 { get; set; }
        private Class3 Class3 { get; set; }
        private string Text { get; set; }
        private DateTime DateTime{ get; set; }
        private double Number { get; set; }
        public Class1(string text, DateTime dateTime, double number)
        {
            Text = text;
            DateTime = dateTime;
            Number = number;
        }
    }
}
