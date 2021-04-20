using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;



namespace Business_Logic.Models
{
    public class Verkoop
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("Lamp")]
        public int LampId { get; set; }

        public virtual Lamp Lamp { get; set; }

        public int Aantal { get; set; }

    }
}
