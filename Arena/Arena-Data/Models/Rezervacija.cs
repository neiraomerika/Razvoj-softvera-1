using System;
using System.Collections.Generic;
using System.Text;

namespace Arena.Models
{
    public class Rezervacija
    {
        public int ID { get; set; }

        public int TerminID { get; set; }
        public Termin Termin { get; set; }

        public int? UplataID { get; set; }
        public Uplata Uplata { get; set; }

        public int KlijentID { get; set; }
        public Klijent Klijent { get; set; }
        public bool OdobrenaRezervacija { get; set; }
    }
}
