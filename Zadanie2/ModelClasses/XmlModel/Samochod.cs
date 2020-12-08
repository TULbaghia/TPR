using System.Collections.Generic;
using System.Xml.Serialization;

namespace ModelClasses.XmlModel
{
    [XmlTypeAttribute(AnonymousType = true, Namespace = "http://p.lodz.pl")]
    public class Samochod
    {
        public string Marka { get; set; }
        public string Model { get; set; }
        public short RokProdukcji { get; set; }
        public int Przebieg { get; set; }
        public double Cena { get; set; }
        public Samochod() { }
        public Samochod(string marka, string model, short rokProdukcji, int przebieg, double cena)
        {
            Marka = marka;
            Model = model;
            RokProdukcji = rokProdukcji;
            Przebieg = przebieg;
            Cena = cena;
        }

        public override bool Equals(object obj)
        {
            return obj is Samochod samochod &&
                   Marka == samochod.Marka &&
                   Model == samochod.Model &&
                   RokProdukcji == samochod.RokProdukcji &&
                   Przebieg == samochod.Przebieg &&
                   Cena == samochod.Cena;
        }

        public override int GetHashCode()
        {
            int hashCode = -2122499966;
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Marka);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Model);
            hashCode = hashCode * -1521134295 + RokProdukcji.GetHashCode();
            hashCode = hashCode * -1521134295 + Przebieg.GetHashCode();
            hashCode = hashCode * -1521134295 + Cena.GetHashCode();
            return hashCode;
        }

        public override string ToString()
        {
            return " \"Samochod\": { Marka: " + Marka + ", Model: " + Model + ", Rok produkcji: " + RokProdukcji + ", Przebieg: " + Przebieg + ", Cena: " + Cena + " }";
        }
    }
}
