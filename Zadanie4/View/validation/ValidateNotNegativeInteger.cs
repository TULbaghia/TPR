using System.Globalization;
using System.Windows.Controls;

namespace PresenterView.validation
{
    public class ValidateNotNegativeInteger : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            if (value == null)
            {
                return new ValidationResult(false, "Wartosc nie moze być nullem");
            }
            if (!int.TryParse(value.ToString(), NumberStyles.Integer, cultureInfo, out int result))
            {
                return new ValidationResult(false, "Wartosc musi byc liczbą");
            }
            if (result < 0)
            {
                return new ValidationResult(false, "Wartosc musi być dodatnia");
            }
            return ValidationResult.ValidResult;
        }
    }
}
