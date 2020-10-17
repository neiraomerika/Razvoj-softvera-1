using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Arena.Web.ViewModels
{
    public class LoginVM
    {
        [Required(ErrorMessage = "Korisnicko ime je obavezno.")]
        [Display(Name ="Korisničko ime", Prompt ="Upišite korisničko ime")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Lozinka je obavezna.")]
        [DataType(DataType.Password)]
        [Display(Name ="Lozinka", Prompt ="Upišite lozinku")]
        public string Password { get; set; }

        [Display(Name = "Zapamti password", Prompt = "Zapamti password")]
        public bool ZapamtiPassword { get; set; }
    }
}
