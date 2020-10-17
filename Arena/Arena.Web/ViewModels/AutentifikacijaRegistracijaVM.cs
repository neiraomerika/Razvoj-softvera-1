using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Arena.Web.ViewModels
{
    public class AutentifikacijaRegistracijaVM
    {
        
        public string Ime { get; set; }
       
        public string Prezime { get; set; }
        public string Spol { get; set; }
        
        public string JBMG { get; set; }
       
        public string KorisnickoIme { get; set; }
        
        public string Password { get; set; }
        
        public string email { get; set; }

       
        public int GradID { get; set; }
    }
}
