using System;
using System.Collections.Generic;
using System.Text;

namespace Arena.Models
{
    public class Uposlenik
    {
        public int ID { get; set; }

        public string Ime { get; set; }
        public string Prezime { get; set; }
        public string BrojTelefona { get; set; }

        public string UserId { get; set; }
        public  Nalog User { get; set; }

        public int TipUposlenikaID { get; set; }
        public TipUposlenika TipUposlenika { get; set; }

        public int GradID { get; set; }
        public Grad Grad { get; set; }

        public int PlataID { get; set; }
        public Plata Plata { get; set; }
    }
}
