using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Arena.Web.ViewModels.Termini
{
    public class TerminPretragaVM
    {

        [Display(Name ="Dvorana")]
        public int? DvoranaId { get; set; }
        public List<SelectListItem> Dvorane{ get; set; }



        public List<TerminIndexVM> RezultatPretrage{ get; set; }


    }
}
