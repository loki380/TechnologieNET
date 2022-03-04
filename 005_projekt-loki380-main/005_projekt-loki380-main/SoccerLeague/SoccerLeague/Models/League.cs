using SoccerLeague.Validators;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SoccerLeague.Models
{
    public class League
    {
        public int ID { get; set; }

        [Required]
        [Display(Name = "Name of the League")]
        [StringLength(30, ErrorMessage = "League name is way too long.")]
        public string LeagueName { get; set; }

        [Required]
        [StringLength(30, ErrorMessage = "Name is way too long.")]
        [FullName]
        public string Chairman { get; set; }

        public IEnumerable<Team> Teams { get; set; }
    }
}
