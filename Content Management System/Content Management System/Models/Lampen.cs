using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Content_Management_System.Models
{
    public class Lampen
    {
        private LampenContext context;
        public int id { get; set; }

        public string Model { get; set; }

        public string Watt { get; set; }

        public string Volt { get; set; }

    }
}
