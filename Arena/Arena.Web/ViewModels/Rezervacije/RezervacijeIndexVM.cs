using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Arena.Web.ViewModels.Rezervacije
{
    public class RezervacijeIndexVM
    {
        public int ID { get; set; }
        public int TerminID { get; set; }

        public DateTime DatumIVrijemeTermina { get; set; }
        public string NazivDvorane { get; set; }
        public bool Placeno { get; set; }

        public string Ime { get; set; }
        public string Prezime { get; set; }

        public bool OdobrenaRezervacija { get; set; }
    }
}
