using System.Collections.Generic;

namespace ModelClasses.XmlModel
{
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://p.lodz.pl")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://p.lodz.pl", IsNullable = false)]
    public class Katalog
    {
        [System.Xml.Serialization.XmlElementAttribute("Samochod")]
        public List<Samochod> Samochody { get; set; } = new List<Samochod>();
    }
}
