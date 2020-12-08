using System.Collections.Generic;
using System.Text;

namespace ModelClasses.XmlModel
{
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://p.lodz.pl")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://p.lodz.pl", IsNullable = false)]
    public class Katalog
    {
        [System.Xml.Serialization.XmlElementAttribute("Samochod")]
        public List<Samochod> Samochody { get; set; } = new List<Samochod>();

        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append("Samochody:\n");
            stringBuilder.Append(string.Join(", \n", Samochody));
            return stringBuilder.ToString();
        }
    }

}
