using System;
using System.Collections.Generic;

namespace Zadanie1.Data
{
    public class Stan
    {
        public Stan(Ksiazka ksiazka, string opis, bool czyWypozyczona, DateTime dataZakupu)
        {
            Ksiazka = ksiazka;
            Opis = opis;
            CzyWypozyczona = czyWypozyczona;
            DataZakupu = dataZakupu;
        }

        public Stan(Ksiazka ksiazka, string opis, bool czyWypozyczona) : this(ksiazka, opis, czyWypozyczona, DateTime.Now)
        {
        }

        public Ksiazka Ksiazka { get; set; }
        public string Opis { get; set; }
        public bool CzyWypozyczona { get; set; }
        public DateTime DataZakupu { get; set; }

        public override bool Equals(object obj)
        {
            return obj is Stan stan &&
                   EqualityComparer<Ksiazka>.Default.Equals(Ksiazka, stan.Ksiazka) &&
                   Opis == stan.Opis &&
                   CzyWypozyczona == stan.CzyWypozyczona &&
                   DataZakupu == stan.DataZakupu;
        }

        public override int GetHashCode()
        {
            int hashCode = -2010857612;
            hashCode = hashCode * -1521134295 + EqualityComparer<Ksiazka>.Default.GetHashCode(Ksiazka);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Opis);
            hashCode = hashCode * -1521134295 + CzyWypozyczona.GetHashCode();
            hashCode = hashCode * -1521134295 + DataZakupu.GetHashCode();
            return hashCode;
        }

        public override string ToString()
        {
            return "OpisStanu[ Ksiazka(" + Ksiazka + "), Opis(" + Opis + "), CzyWypozyczona(" + CzyWypozyczona + "), DataZakupu(" + DataZakupu + ") ]";
        }

    }
}
