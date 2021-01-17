using System.Globalization;
using System.Linq;
using System.Windows.Controls;

namespace PresenterView.validation
{
    public class Validation50characters : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            if (value == null)
            {
                return new ValidationResult(false, "Wartosc nie moze być nullem");
            }
            if (value.ToString().Count() >= 50)
            {
                return new ValidationResult(false, "Wartosc nie moze byc dluzsza niz 50 znaków");
            }
            return ValidationResult.ValidResult;
        }
    }
}
