using System;
using System.Collections.Generic;

namespace Zadanie1.Data.Model
{
    public class Zdarzenie
    {
        public Klient Klient { get; set; }
        public Stan Stan { get; set; }
        public DateTime Data { get; set; }

        public Zdarzenie(Klient klient, Stan stan, DateTime data)
        {
            Klient = klient;
            Stan = stan;
            Data = data;
        }

        public Zdarzenie(Klient klient, Stan stan) : this(klient, stan, DateTime.Now)
        {
        }

        public override bool Equals(object obj)
        {
            return obj is Zdarzenie zdarzenie &&
                   EqualityComparer<Klient>.Default.Equals(Klient, zdarzenie.Klient) &&
                   EqualityComparer<Stan>.Default.Equals(Stan, zdarzenie.Stan) &&
                   Data == zdarzenie.Data;
        }

        public override int GetHashCode()
        {
            int hashCode = -813586821;
            hashCode = hashCode * -1521134295 + EqualityComparer<Klient>.Default.GetHashCode(Klient);
            hashCode = hashCode * -1521134295 + EqualityComparer<Stan>.Default.GetHashCode(Stan);
            hashCode = hashCode * -1521134295 + Data.GetHashCode();
            return hashCode;
        }

        public override string ToString()
        {
            return "Zdarzenie[ wykaz(" + Klient + "), opisStanu(" + Stan + "), data(" + Data + ") ]";
        }
    }
}
