using System;
using System.Collections.Generic;
using System.Text;

namespace Arena.Models
{
    public class Klijent
    {
        public int ID { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public string Spol { get; set; }
        public string JBMG { get; set; }

        public int GradID { get; set; }
        public Grad Grad { get; set; }

        public string UserId { get; set; }
        public  Nalog User { get; set; }
    }

}
