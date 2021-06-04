using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CMS_Individueel_Project.Data.Models
{
    public class Producent
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Naam { get; set; }

        [Required]
        public string Rekeningnummer { get; set; }

        public string Gemeente { get; set; }

        public string Straat { get; set; }

        public string Huisnummer { get; set; }

        public string PostCode { get; set; }
    }
}
