using System;
using System.Collections.Generic;
using System.Text;

namespace Zadanie1
{
    public class Katalog
    {
        public Katalog(int id, string nazwa, string producent)
        {
            Id = id;
            Nazwa = nazwa;
            Producent = producent;
        }

        public int Id { get; set; }
        public string Nazwa { get; set; }
        public string Producent { get; set; }

        public override bool Equals(object obj)
        {
            return obj is Katalog katalog &&
                   Id == katalog.Id &&
                   Nazwa == katalog.Nazwa &&
                   Producent == katalog.Producent;
        }

        public override int GetHashCode()
        {
            int hashCode = 998198611;
            hashCode = hashCode * -1521134295 + Id.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Nazwa);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Producent);
            return hashCode;
        }

        public override string ToString()
        {
            return this.Id + ", " + this.Nazwa + ", " + this.Producent;
        }
    }
}
