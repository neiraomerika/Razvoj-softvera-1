using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Arena.Web.ViewModels.Rezervacije
{
    public class RezervacijePretragaVM
    {

        [Display(Name = "Dvorana")]
        public int? OdabranaDvorana { get; set; }
        public List<SelectListItem> Dvorane { get; set; }
        [Display(Name = "Ime klijenta", Prompt ="Upišite ime klijenta")]
        public string ImeKlijenta { get; set; }
        [Display(Name="Prezime klijenta",Prompt ="Upišite prezime klijenta")]
        public string PrezimeKlijenta { get; set; }


        public List<RezervacijeIndexVM> RezultatPretrage { get; set; }
    }
}
