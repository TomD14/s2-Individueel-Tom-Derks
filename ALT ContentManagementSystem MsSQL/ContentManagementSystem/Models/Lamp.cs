using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace ContentManagementSystem.Models
{
    public class Lamp
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Model { get; set; }

        public int Watt { get; set; }

        public int Kleur { get; set; }

        public int Aantal { get; set; }
    }
}
