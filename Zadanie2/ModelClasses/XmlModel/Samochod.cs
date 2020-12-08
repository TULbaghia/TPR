namespace ModelClasses.XmlModel
{
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://p.lodz.pl")]
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

        public override string ToString()
        {
            return " \"Samochod\": { Marka: " + Marka + ", Model: " + Model + ", Rok produkcji: " + RokProdukcji + ", Przebieg: " + Przebieg + ", Cena: " + Cena + " }";
        }
    }
}
