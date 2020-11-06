using System;
using System.Collections.Generic;
using System.Dynamic;

namespace Zadanie1.Data
{
    public class Stan
    {
        public Ksiazka Ksiazka { get; set; }
        public string Opis { get; set; }
        public int Ilosc { get; set; }
        public DateTime DataZakupu { get; set; }

        public Stan(Ksiazka ksiazka, string opis, int ilosc, DateTime dataZakupu)
        {
            Ksiazka = ksiazka;
            Opis = opis;
            Ilosc = ilosc;
            DataZakupu = dataZakupu;
        }

        public Stan(Ksiazka ksiazka, string opis, int ilosc) : this(ksiazka, opis, ilosc, DateTime.Now)
        {
        }


        public override string ToString()
        {
            return "OpisStanu[ Katalog(" + Ksiazka + "), Opis(" + Opis + "), DataZakupu(" + DataZakupu + ") ]";
        }

        public override bool Equals(object obj)
        {
            return obj is Stan stan &&
                   EqualityComparer<Ksiazka>.Default.Equals(Ksiazka, stan.Ksiazka) &&
                   Opis == stan.Opis &&
                   Ilosc == stan.Ilosc &&
                   DataZakupu == stan.DataZakupu;
        }

        public override int GetHashCode()
        {
            int hashCode = 1635283009;
            hashCode = hashCode * -1521134295 + EqualityComparer<Ksiazka>.Default.GetHashCode(Ksiazka);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Opis);
            hashCode = hashCode * -1521134295 + Ilosc.GetHashCode();
            hashCode = hashCode * -1521134295 + DataZakupu.GetHashCode();
            return hashCode;
        }
    }
}
