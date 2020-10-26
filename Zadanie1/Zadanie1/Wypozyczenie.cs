using System;
using System.Collections.Generic;
using System.Text;

namespace Zadanie1
{
    public class Wypozyczenie : Zdarzenie
    {
        public Wypozyczenie(int id, Wykaz wykaz, OpisStanu opisStanu) : base(id, wykaz, opisStanu)
        {
        }

        public Wypozyczenie(int id, Wykaz wykaz, OpisStanu opisStanu, DateTime data) : base(id, wykaz, opisStanu, data)
        {
        }

        public override string ToString()
        {
            return "Wyporzyczenie{ " + base.ToString() + " }";
        }
    }
}
