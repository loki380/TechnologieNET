using SoccerLeague.Validators;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SoccerLeague.Models
{
    public class Team
    {
        public int ID { get; set; }

        [Required]
        [Display(Name = "Name of the team")]
        [StringLength(30, ErrorMessage = "Name is way too long.")]
        public String TeamName { get; set; }

        [Url]
        [Display(Name = "Photo Link")]
        public String PhotoLink { get; set; }

        [Required]
        [StringLength(30, ErrorMessage = "Name is way too long.")]
        [FullName]
        public String Coach { get; set; }

        public int LeagueID { get; set; }
        public League League { get; set; }

        public IEnumerable<Player> Players { get; set; }
    }
}
