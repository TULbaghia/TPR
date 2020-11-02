using System;
using System.Collections.Generic;
using System.Text;

namespace Zadanie1
{
    public class Zdarzenie
    {
        public int Id { get; set; }
        public Klient Klient { get; set; }
        public Stan Stan { get; set; }
        public DateTime Data { get; set; }

        public Zdarzenie(int id, Klient klient, Stan stan, DateTime data)
        {
            Id = id;
            Klient = klient;
            Stan = stan;
            Data = data;
        }

        public Zdarzenie(int id, Klient klient, Stan stan) : this(id, klient, stan, DateTime.Now)
        {
        }

        public override bool Equals(object obj)
        {
            return obj is Zdarzenie zdarzenie &&
                   Id == zdarzenie.Id &&
                   EqualityComparer<Klient>.Default.Equals(Klient, zdarzenie.Klient) &&
                   EqualityComparer<Stan>.Default.Equals(Stan, zdarzenie.Stan) &&
                   Data == zdarzenie.Data;
        }

        public override int GetHashCode()
        {
            int hashCode = -813586821;
            hashCode = hashCode * -1521134295 + Id.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<Klient>.Default.GetHashCode(Klient);
            hashCode = hashCode * -1521134295 + EqualityComparer<Stan>.Default.GetHashCode(Stan);
            hashCode = hashCode * -1521134295 + Data.GetHashCode();
            return hashCode;
        }

        public override string ToString()
        {
            return "Zdarzenie[ id(" + Id + "), wykaz(" + Klient + "), opisStanu(" + Stan + "), data(" + Data + ") ]";
        }
    }
}
