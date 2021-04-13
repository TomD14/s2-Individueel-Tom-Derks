using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Content_Management_System.Models
{
    public class Lamp
    {
        private LampContext context;

        public int Id { get; set; }

        [Required]
        public string Model { get; set; }

        [Required]
        public int Watt { get; set; }

        [Required]
        public int Kleur { get; set; }

        [Required]
        public int Aantal { get; set; }
    }
}
