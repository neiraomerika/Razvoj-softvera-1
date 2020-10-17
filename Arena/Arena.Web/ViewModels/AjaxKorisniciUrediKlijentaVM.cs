using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Arena.Web.ViewModels
{
    public class AjaxKorisniciUrediKlijentaVM
    {
        public int ID { get; set; }
        public string Username { get; set; }
        public string Lozinka { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public string Spol { get; set; }
        public string JMBG { get; set; }

        public List<SelectListItem> Gradovi { get; set; }

    }
}
