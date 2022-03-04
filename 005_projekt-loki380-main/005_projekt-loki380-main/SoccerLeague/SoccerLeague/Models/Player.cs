using Microsoft.Extensions.Logging;
using SoccerLeague.Validators;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SoccerLeague.Models
{
    public class Player : IValidatableObject
    {

        public int ID { get; set; }

        [Required]
        [StringLength(30, ErrorMessage = "First Name is way too long.")]
        public string Firstname { get; set; }
        
        [Required]
        [StringLength(30, ErrorMessage = "Last Name is way too long.")]
        public string Lastname { get; set; }

        [Required]
        public string Position { get; set; }

        [Required]
        [Display(Name = "Birth date")]
        [DataType(DataType.Date)]
        [LegalAge]
        public DateTime DateOfBirth { get; set; }

        [Required]
        [Display(Name = "Height (cm)")]
        public uint Height { get; set; }

        [Required]
        [Display(Name = "Weight (kg)")]
        public uint Weight { get; set; }

        [Required]
        [Range(0, 100,
        ErrorMessage = "Value for {0} must be between {1} and {2}.")]
        public uint Points { get; set; }

        [ForeignKey("Team")]
        [Display(Name = "Team")]
        public int TeamID { get; set; }
        public virtual Team Team { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var BMI = Weight/(((float)Height/100)*((float)Height / 100));

            if (BMI < 16 || BMI > 40)
            {
                yield return new ValidationResult("This weight is unrealistic with such an height", new List<string> { "Weight" });
            }
        }
    }
}
