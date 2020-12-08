using ModelClasses.XmlModel;

namespace SerializerTests
{
    class TestXmlDataFiller : IXmlDataFiller
    {
        public void Fill(Katalog katalog)
        {
            katalog.Samochody.Add(new Samochod("Fiat", "Punto", 1997, 123951, 6536));
            katalog.Samochody.Add(new Samochod("Opel", "Kadet", 1986, 5182575, 913));
            katalog.Samochody.Add(new Samochod("Ford", "Mustang", 1968, 230498, 12637));
            katalog.Samochody.Add(new Samochod("Peugeot", "306", 2018, 1254, 71945));
            katalog.Samochody.Add(new Samochod("Tesla", "Roadster", 2020, 1273, 948325));
        }
    }
}
