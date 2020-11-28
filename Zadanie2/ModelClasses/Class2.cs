using System;
using System.Collections.Generic;
using System.Text;

namespace ModelClasses
{
    class Class2
    {
        private Class1 Class1 { get; set; }
        private Class3 Class3 { get; set; }
        private string Text { get; set; }
        private DateTime DateTime { get; set; }
        private double Number { get; set; }
        public Class2(string text, DateTime dateTime, double number)
        {
            Text = text;
            DateTime = dateTime;
            Number = number;
        }
    }
}
