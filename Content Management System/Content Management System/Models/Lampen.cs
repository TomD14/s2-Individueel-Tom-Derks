using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Content_Management_System.Models
{
    public class Lampen
    {
        private LampContext context;
        public int Id { get; set; }

        public string Model { get; set; }

        public int Watt { get; set; }

        public int Volt { get; set; }

        public int Hertz { get; set; }

        public int Kleur { get; set; }

        public int Aantal { get; set; }
    }
}
