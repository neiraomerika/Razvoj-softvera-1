using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Arena.Web.ViewModels.Rezervacije
{
    public class RezervacijaDodajVM
    {
        [Required(ErrorMessage = "Molimo odaberite termin.")]
        public int? OdabraniTerminId { get; set; }
        public List<SelectListItem> Termini { get; set; }

        [Required(ErrorMessage = "Molimo odaberite klijenta.")]
        public int? OdabraniKlijentId{ get; set; }
        public List<SelectListItem> Klijenti{ get; set; }
    }
}
