using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace ModelClasses.XmlModel
{
    [XmlTypeAttribute(AnonymousType = true, Namespace = "http://p.lodz.pl")]
    [XmlRootAttribute(Namespace = "http://p.lodz.pl", IsNullable = false)]
    public class Katalog
    {
        [XmlElementAttribute("Samochod")]
        public List<Samochod> Samochody { get; set; } = new List<Samochod>();

        public override bool Equals(object obj)
        {
            return obj is Katalog katalog &&
                   EqualityComparer<List<Samochod>>.Default.Equals(Samochody, katalog.Samochody);
        }

        public override int GetHashCode()
        {
            return 1079671600 + EqualityComparer<List<Samochod>>.Default.GetHashCode(Samochody);
        }

        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append("Samochody:\n");
            stringBuilder.Append(string.Join(", \n", Samochody));
            return stringBuilder.ToString();
        }

    }

}
