using System;
using System.Collections.Generic;
using System.Text;

namespace Zadanie1
{
    public class Ksiazka
    {
        public Ksiazka(int id, string tytul, string autor)
        {
            Id = id;
            Tytul = tytul;
            Autor = autor;
        }

        public int Id { get; set; }
        public string Tytul { get; set; }
        public string Autor { get; set; }

        public override bool Equals(object obj)
        {
            return obj is Ksiazka ksiazka &&
                   Id == ksiazka.Id &&
                   Tytul == ksiazka.Tytul &&
                   Autor == ksiazka.Autor;
        }

        public override int GetHashCode()
        {
            int hashCode = 1728777499;
            hashCode = hashCode * -1521134295 + Id.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Tytul);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Autor);
            return hashCode;
        }

        public override string ToString()
        {
            return this.Id + ", " + this.Tytul + ", " + this.Autor;
        }
    }

}
