using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Controls;

namespace Tennisclub_WPF.Validations
{
    public class NumberValidationRule : ValidationRule
    {
        private string _pattern;
        private Regex _regex;

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
            if (value == null)
            {
                return new ValidationResult(false, "This field is required.");
            }
            else if (!_regex.Match(value.ToString()).Success)
            {
                return new ValidationResult(false, "This field can only contain numbers.");
            }
            else
            {
                return new ValidationResult(true, null);
            }
        }
    }
}
