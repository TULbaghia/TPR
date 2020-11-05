using System;
using System.Collections.Generic;

namespace Zadanie1.Data.Model
{
    public class Stan
    {
        public Ksiazka Ksiazka { get; set; }
        public string Opis { get; set; }
        public DateTime DataZakupu { get; set; }

        public Stan(Ksiazka ksiazka, string opis, DateTime dataZakupu)
        {
            Ksiazka = ksiazka;
            Opis = opis;
            DataZakupu = dataZakupu;
        }

        public Stan(Ksiazka ksiazka, string opis) : this(ksiazka, opis, DateTime.Now)
        {
        }

        public override bool Equals(object obj)
        {
            return obj is Stan stan &&
                   EqualityComparer<Ksiazka>.Default.Equals(Ksiazka, stan.Ksiazka) &&
                   Opis == stan.Opis &&
                   DataZakupu == stan.DataZakupu;
        }

        public override int GetHashCode()
        {
            int hashCode = -749868843;
            hashCode = hashCode * -1521134295 + EqualityComparer<Ksiazka>.Default.GetHashCode(Ksiazka);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Opis);
            hashCode = hashCode * -1521134295 + DataZakupu.GetHashCode();
            return hashCode;
        }

        public override string ToString()
        {
            return "OpisStanu[ Katalog(" + Ksiazka + "), Opis(" + Opis + "), DataZakupu(" + DataZakupu + ") ]";
        }
    }
}
