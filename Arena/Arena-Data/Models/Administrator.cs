using System;
using System.Collections.Generic;
using System.Text;

namespace Arena.Models
{
    public class Administrator
    {
        public int ID { get; set; }

        public string UserId { get; set; }
        public  Nalog User { get; set; }

        public string Ime { get; set; }
        public string Prezime { get; set; }

        public int PlataID { get; set; }
        public Plata Plata { get; set; }
    }
}
