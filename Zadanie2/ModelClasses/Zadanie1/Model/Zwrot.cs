using System;

namespace ModelClasses.Zadanie1.Data
{
    public class Zwrot : Zdarzenie
    {
        public Zwrot() { }

        public Zwrot(Klient klient, Stan stan) : base(klient, stan) { }

        public Zwrot(Klient klient, Stan stan, DateTime data) : base(klient, stan, data) { }
        public override bool Equals(object obj)
        {
            return obj is Zwrot && base.Equals(obj);
        }

        public override int GetHashCode()
        {
            int hashCode = 102248927;
            hashCode = hashCode * -1521134295 + base.GetHashCode();
            return hashCode;
        }

        public override string ToString()
        {
            return "Zwrot{ " + base.ToString() + " }";
        }
    }
}
