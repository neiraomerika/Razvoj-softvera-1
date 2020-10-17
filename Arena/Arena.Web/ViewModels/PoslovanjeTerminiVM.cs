using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Arena.Web.ViewModels
{
    public class PoslovanjeTerminiVM
    {
        public List<termins> termini { get; set; }
        public class termins
        {
            public int Id { get; set; }
            public DateTime DatumIVrijeme { get; set; }
            public float Cijena { get; set; }
            public string Dvorana { get; set; }
            public bool Rezervacija { get; set; }
        }

        public List<rezervations> rezervacije { get; set; }
        public class rezervations
        {
            public int Id { get; set; }
            public int TerminId { get; set; }
            public bool Odobrena { get; set; }
            public string Klijent { get; set; }
        }
    }
}
