using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;



namespace CMS_Individueel_Project.Data.Models
{
    public class Verkoop
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [ForeignKey("Lamp")]
        public int LampId { get; set; }

        //[Required]
        public virtual Lamp Lamp { get; set; }

        [Required]
        public int Aantal { get; set; }

    }
}
