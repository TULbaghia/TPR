using System;
using System.Collections.Generic;
using System.Text;

namespace Zadanie1
{
    public class OpisStanu
    {
        public int Id { get; set; }
        public Katalog Katalog { get; set; }
        public string Opis { get; set; }
        public DateTime DataZakupu { get; set; }

        public OpisStanu(int id, Katalog katalog, string opis, DateTime dataZakupu)
        {
            Id = id;
            Katalog = katalog;
            Opis = opis;
            DataZakupu = dataZakupu;
        }

        public override bool Equals(object obj)
        {
            return obj is OpisStanu stanu &&
                   Id == stanu.Id &&
                   EqualityComparer<Katalog>.Default.Equals(Katalog, stanu.Katalog) &&
                   Opis == stanu.Opis &&
                   DataZakupu == stanu.DataZakupu;
        }

        public override int GetHashCode()
        {
            int hashCode = -749868843;
            hashCode = hashCode * -1521134295 + Id.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<Katalog>.Default.GetHashCode(Katalog);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Opis);
            hashCode = hashCode * -1521134295 + DataZakupu.GetHashCode();
            return hashCode;
        }

        public override string ToString()
        {
            return "OpisStanu[ Id(" + Id + "), Katalog(" + Katalog + "), Opis(" + Opis + "), DataZakupu(" + DataZakupu + ") ]";
        }
    }
}
