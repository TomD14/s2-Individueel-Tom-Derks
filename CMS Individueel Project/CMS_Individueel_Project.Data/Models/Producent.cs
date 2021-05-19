using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CMS_Individueel_Project.Data.Models
{
    class Producent
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Naam { get; set; }

        [Required]
        public string Rekeningnummer { get; set; }

        [Required]
        [ForeignKey("Lamp")]
        public int LampId { get; set; }

        [Required]
        [ForeignKey("Adress")]
        public int AdressId { get; set; }
    }
}
