using System.Collections.Generic;

namespace ModelClasses.Zadanie1.Data
{
    public class Ksiazka
    {
        public string Tytul { get; set; }
        public string Autor { get; set; }

        public Ksiazka() { }

        public Ksiazka(string tytul, string autor)
        {
            Tytul = tytul;
            Autor = autor;
        }

        public override bool Equals(object obj)
        {
            return obj is Ksiazka ksiazka &&
                   Tytul == ksiazka.Tytul &&
                   Autor == ksiazka.Autor;
        }

        public override int GetHashCode()
        {
            int hashCode = 1728777499;
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Tytul);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Autor);
            return hashCode;
        }

        public override string ToString()
        {
            return "Ksiazka[ Tytul(" + Tytul + "), Autor(" + Autor + ") ]";
        }
    }

}
