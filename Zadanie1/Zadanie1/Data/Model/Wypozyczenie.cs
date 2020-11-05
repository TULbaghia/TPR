using System;

namespace Zadanie1.Data
{
    public class Wypozyczenie : Zdarzenie
    {
        public Wypozyczenie(Klient klient, Stan stan) : base(klient, stan)
        {
        }

        public Wypozyczenie(Klient klient, Stan stan, DateTime data) : base(klient, stan, data)
        {
        }
        public override bool Equals(object obj)
        {
            return obj is Wypozyczenie && base.Equals(obj);
        }

        public override int GetHashCode()
        {
            int hashCode = 102248929;
            hashCode = hashCode * -1521134295 + base.GetHashCode();
            return hashCode;
        }

        public override string ToString()
        {
            return "Wypozyczenie{ " + base.ToString() + " }";
        }
    }
}
