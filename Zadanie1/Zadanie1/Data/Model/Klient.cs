using System.Collections.Generic;

namespace Zadanie1.Data
{
    public class Klient
    {
        public string Imie { get; set; }
        public string Nazwisko { get; set; }

        public Klient(string imie, string nazwisko)
        {
            Imie = imie;
            Nazwisko = nazwisko;
        }

        public override bool Equals(object obj)
        {
            return obj is Klient klient &&
                   Imie == klient.Imie &&
                   Nazwisko == klient.Nazwisko;
        }

        public override int GetHashCode()
        {
            int hashCode = 763000634;
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Imie);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Nazwisko);
            return hashCode;
        }

        public override string ToString()
        {
            return "Klient[ Imie(" + Imie + "), Nazwisko(" + Nazwisko + ") ]";
        }
    }
}
