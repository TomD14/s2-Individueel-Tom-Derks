using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace CMS_Individueel_Project.Data.Models
{
    public class Adres
    {
        [Key]
        public int Id { get; set; }
        
        [Required]
        public string Gemeente { get; set; }
        
        [Required]
        public string Straat { get; set; }
        
        public string Huisnummer { get; set; }
        
        [Required]
        public string PostCode { get; set; }
        
        [Required]
        public bool ProducentCheck { get; set; }
    }
}
