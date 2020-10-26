using System.Collections.Generic;

namespace Zadanie1
{
    public class Klient
    {
        public Klient(int id, string imie, string nazwisko)
        {
            Id = id;
            Imie = imie;
            Nazwisko = nazwisko;
        }

        public int Id { get; set; }
        public string Imie { get; set; }
        public string Nazwisko { get; set; }

        public override bool Equals(object obj)
        {
            return obj is Klient klient &&
                   Id == klient.Id &&
                   Imie == klient.Imie &&
                   Nazwisko == klient.Nazwisko;
        }

        public override int GetHashCode()
        {
            int hashCode = 763000634;
            hashCode = hashCode * -1521134295 + Id.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Imie);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Nazwisko);
            return hashCode;
        }

        public override string ToString()
        {
            return this.Imie + ", " + this.Nazwisko + ", " + this.Id;
        }
    }
}
