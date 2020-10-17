using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Arena.Web.ViewModels.Korisnici
{
    public class KorisnikZaposlenikDodajVM
    {
        [Required(ErrorMessage ="Ovo polje je obavezno")]
        [Display(Name ="Ime")]
        public string Ime { get; set; }
        [Required(ErrorMessage ="Ovo polje je obavezno")]
        [Display(Name = "Prezime")]
        public string Prezime { get; set; }
        [Required(ErrorMessage ="Ovo polje je obavezno")]
        [Display(Name = "Broj telefona")]
        public string BrojTelefona { get; set; }

        [Required(ErrorMessage ="Ovo polje je obavezno")]
        [Display(Name = "Korisnicko ime")]
        public string Username { get; set; }
        [Required(ErrorMessage ="Ovo polje je obavezno")]
        [Display(Name = "Lozinka")]
        public string Password { get; set; }

        [Required(ErrorMessage ="Ovo polje je obavezno")]
        [Display(Name = "Tip uposlenika")]
        public int? TipUposlenikaID { get; set; }
        public List<SelectListItem> TipoviUposlenika { get; set; }

        [Required(ErrorMessage ="Ovo polje je obavezno")]
        [Display(Name = "Grad")]
        public int? GradID { get; set; }
        public List<SelectListItem> Gradovi { get; set; }

        [Required(ErrorMessage ="Ovo polje je obavezno")]
        [Display(Name = "Plata")]
        public int? PlataID { get; set; }
        public List<SelectListItem> Plate { get; set; }
    }
}
