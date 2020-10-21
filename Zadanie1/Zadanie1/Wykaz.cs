using System;
using System.Collections.Generic;
using System.Runtime.InteropServices.ComTypes;

namespace Zadanie1
{
    public class Wykaz
    {
        public Wykaz(string Id, string imie, string nazwisko)
        {
            this.Id = Id;
            this.Imie = imie;
            this.Nazwisko = nazwisko;
        }

        public string Id { get; set; }
        public string Imie { get; set; }
        public string Nazwisko { get; set; }

        public override bool Equals(object obj)
        {
            return obj is Wykaz wykaz &&
                   Id == wykaz.Id &&
                   Imie == wykaz.Imie &&
                   Nazwisko == wykaz.Nazwisko;
        }

        public override int GetHashCode()
        {
            int hashCode = -1163834168;
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Id);
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
