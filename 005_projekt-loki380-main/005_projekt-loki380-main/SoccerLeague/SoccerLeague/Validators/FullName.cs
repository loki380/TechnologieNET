using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SoccerLeague.Validators
{
    public class FullName : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var content = Convert.ToString(value);
            string[] subs = content.Split(' ','-');
            var length = subs.Length;
            if(length<2)
            {
                return new ValidationResult("The field must contain First Name and Last Name");
            }
            else if (length == 2)
            {
                if (Char.IsUpper(subs[0], 0) && Char.IsUpper(subs[1], 0))
                {
                    return null;
                }
            }
            else if (length == 3)
            {
                if (Char.IsUpper(subs[0], 0) && Char.IsUpper(subs[1], 0) && Char.IsUpper(subs[2], 0))
                {
                    return null;
                }
            }

            return new ValidationResult("First Name and Last Name should start with big letters");
        }
    }
}
