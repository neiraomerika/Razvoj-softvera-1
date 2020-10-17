using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Arena.Web.ViewModels
{
    public class AjaxKlijentiVM
    {
        public List<klijent> klijenti { get; set; }

        public class klijent
        {
            public int ID { get; set; }
            public string Username { get; set; }
            public string Ime { get; set; }
            public string Prezime { get; set; }
            public string Spol { get; set; }
            public string JMBG { get; set; }
            public string Grad { get; set; }

        }
    }
}
