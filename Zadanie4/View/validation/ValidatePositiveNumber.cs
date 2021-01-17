using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace PresenterView.validation
{
    public class ValidatePositiveNumber : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            if(value == null)
            {
                return new ValidationResult(false, "Wartosc nie moze być nullem");
            }
            if(!short.TryParse(value.ToString(), NumberStyles.Integer, cultureInfo, out short result))
            {
                return new ValidationResult(false, "Wartosc musi byc liczbą");
            }
            if(result <= 0)
            {
                return new ValidationResult(false, "Wartosc musi być dodatnia");
            }
            return ValidationResult.ValidResult;
        }
    }
}
