using System;
using System.Collections.Generic;
using System.Text;

namespace Zadanie1
{
    public class Stan
    {
        public int Id { get; set; }
        public Ksiazka Ksiazka { get; set; }
        public string Opis { get; set; }
        public DateTime DataZakupu { get; set; }

        public Stan(int id, Ksiazka ksiazka, string opis, DateTime dataZakupu)
        {
            Id = id;
            Ksiazka = ksiazka;
            Opis = opis;
            DataZakupu = dataZakupu;
        }

        public override bool Equals(object obj)
        {
            return obj is Stan stan &&
                   Id == stan.Id &&
                   EqualityComparer<Ksiazka>.Default.Equals(Ksiazka, stan.Ksiazka) &&
                   Opis == stan.Opis &&
                   DataZakupu == stan.DataZakupu;
        }

        public override int GetHashCode()
        {
            int hashCode = -749868843;
            hashCode = hashCode * -1521134295 + Id.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<Ksiazka>.Default.GetHashCode(Ksiazka);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Opis);
            hashCode = hashCode * -1521134295 + DataZakupu.GetHashCode();
            return hashCode;
        }

        public override string ToString()
        {
            return "OpisStanu[ Id(" + Id + "), Katalog(" + Ksiazka + "), Opis(" + Opis + "), DataZakupu(" + DataZakupu + ") ]";
        }
    }
}
