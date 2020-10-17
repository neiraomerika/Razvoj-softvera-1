using Arena.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Arena.Web.ViewModels.Termini
{
    public class TerminDodajVM
    {
        [Display(Name ="Datum i vrijeme termina")]
        [DataType(DataType.DateTime)]
        public DateTime DatumIVrijeme { get; set; }
       

        
        [Display(Name ="Dvorana za termin")]
        public int OdabranaDvoranaId { get; set; }
        public List<SelectListItem> Dvorane{ get; set; }

       
        [Display(Name ="Cijena termina")]
        public decimal Cijena { get; set; }

    }
}
