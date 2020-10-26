using System;
using System.Collections.Generic;
using System.Text;

namespace Zadanie1
{
    public class Zdarzenie
    {
        public int Id { get; set; }
        public Wykaz Wykaz { get; set; }
        public OpisStanu OpisStanu { get; set; }
        public DateTime Data { get; set; }

        public Zdarzenie(int id, Wykaz wykaz, OpisStanu opisStanu, DateTime data)
        {
            Id = id;
            Wykaz = wykaz;
            OpisStanu = opisStanu;
            Data = data;
        }

        public Zdarzenie(int id, Wykaz wykaz, OpisStanu opisStanu) : this(id, wykaz, opisStanu, DateTime.Now)
        {
        }

        public override bool Equals(object obj)
        {
            return obj is Zdarzenie zdarzenie &&
                   Id == zdarzenie.Id &&
                   EqualityComparer<Wykaz>.Default.Equals(Wykaz, zdarzenie.Wykaz) &&
                   EqualityComparer<OpisStanu>.Default.Equals(OpisStanu, zdarzenie.OpisStanu) &&
                   Data == zdarzenie.Data;
        }

        public override int GetHashCode()
        {
            int hashCode = -813586821;
            hashCode = hashCode * -1521134295 + Id.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<Wykaz>.Default.GetHashCode(Wykaz);
            hashCode = hashCode * -1521134295 + EqualityComparer<OpisStanu>.Default.GetHashCode(OpisStanu);
            hashCode = hashCode * -1521134295 + Data.GetHashCode();
            return hashCode;
        }

        public override string ToString()
        {
            return "Zdarzenie[ id(" + Id + "), wykaz(" + Wykaz + "), opisStanu(" + OpisStanu + "), data(" + Data + ") ]";
        }
    }
}
