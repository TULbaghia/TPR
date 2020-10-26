using System;
using System.Collections.Generic;
using System.Text;

namespace Zadanie1
{
    public class Zwrot : Zdarzenie
    {
        public Zwrot(int id, Wykaz wykaz, OpisStanu opisStanu) : base(id, wykaz, opisStanu)
        {
        }

        public Zwrot(int id, Wykaz wykaz, OpisStanu opisStanu, DateTime data) : base(id, wykaz, opisStanu, data)
        {
        }

        public override string ToString()
        {
            return "Zwrot{ " + base.ToString() + " }";
        }
    }
}
