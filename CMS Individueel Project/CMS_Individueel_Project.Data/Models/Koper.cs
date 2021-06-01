using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CMS_Individueel_Project.Data.Models
{
    public class Koper
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Naam { get; set; }
        
        [Required]
        public string Rekeningnummer { get; set; }
        
        [Required]
        [ForeignKey("Verkoop")]
        public int VerkoopId { get; set; }

        [Required]
        [ForeignKey("Adress")]
        public int Adress { get; set; }
    }
}
