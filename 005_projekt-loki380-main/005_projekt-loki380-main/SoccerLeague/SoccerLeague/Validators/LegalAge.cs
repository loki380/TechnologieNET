using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SoccerLeague.Validators
{
    public class LegalAge : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var content = Convert.ToDateTime(value);
            var today = DateTime.Today;

            var age = today.Year - content.Year;

            if(content.Date > today.AddYears(-age)) age--;

            if (age > 16)
            {
                return null;
            }
            else
            {
                return new ValidationResult("Legal age start from 16");
            }

        }
    }
}
