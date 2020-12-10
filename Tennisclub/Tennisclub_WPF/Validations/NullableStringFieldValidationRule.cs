using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Windows.Controls;

namespace Tennisclub_WPF.Validations
{
    public class NullableStringFieldValidationRule : ValidationRule
    {
        public int Length { get; set; }

        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            if (value?.ToString().Length > Length)
            {
                return new ValidationResult(false, $"This field cannot be longer than {Length} characters");
            }
            return new ValidationResult(true, null);
        }
    }
}
