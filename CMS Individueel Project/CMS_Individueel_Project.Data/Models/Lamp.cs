using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CMS_Individueel_Project.Data.Models
{
    public class Lamp
    {
        [Key]
        public int Id { get; set; }

        [StringLength(60, MinimumLength = 3)]
        [Required]
        public string Model { get; set; }

        [Required]
        public int Watt { get; set; }

        [Required]
        public int Kleur { get; set; }

        [DataType(DataType.Currency)]
        public decimal Prijs { get; set; }

        [ForeignKey("Producent")]
        public int ProducentId { get; set; }

        public virtual Producent Producent { get; set; }

        [Required]
        public int Aantal { get; set; }
    }
}
