using Business_Logic.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CMS_Individueel_Project.Contract
{
    class VerkoopDTO
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("Lamp")]
        public int LampId { get; set; }

        public virtual Lamp Lamp { get; set; }

        public int Aantal { get; set; }
    }
}
