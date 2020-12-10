using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Controls;

namespace Tennisclub_WPF.Validations
{
    public class RequiredStringFieldValidationRule : ValidationRule
    {
        private string _pattern;
        private Regex _regex;
        public int Length { get; set; }

        public string Pattern
        {
            get { return _pattern; }
            set
            {
                _pattern = value;
                _regex = new Regex(_pattern, RegexOptions.IgnoreCase);
            }
        }

        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            if (value == null || _regex.Match(value.ToString()).Success)
            {
                return new ValidationResult(false, "This field is required.");
            }
            else if (value.ToString().Length > Length)
            {
                return new ValidationResult(false, $"This field cannot be longer than {Length} characters");
            }
            else
            {
                return new ValidationResult(true, null);
            }
        }
    }
}
