using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Arena.Web.ViewModels.Korisnici
{
    public class KorisnikIndexVM
    {
        public bool IsKlijent { get; set; }
        public bool IsAdministrator { get; set; }
        public bool IsUposlenik { get; set; }


        public int ID { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public string Spol { get; set; }
        public string JMBG { get; set; }
        public string Grad { get; set; }
        public string Username { get; set; }
    }
}
