using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace forma1Example.Models
{
    public class Team
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public int Year { get; set; }

        [Required]
        public int Won { get; set; }

        [Required]
        public bool Paid { get; set; }


    }
}
