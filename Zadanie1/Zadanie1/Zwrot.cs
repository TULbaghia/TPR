using System;
using System.Collections.Generic;
using System.Text;

namespace Zadanie1
{
    public class Zwrot : Zdarzenie
    {
        public Zwrot(int id, Klient klient, Stan stan) : base(id, klient, stan)
        {
        }

        public Zwrot(int id, Klient klient, Stan stan, DateTime data) : base(id, klient, stan, data)
        {
        }

        public override string ToString()
        {
            return "Zwrot{ " + base.ToString() + " }";
        }
    }
}
