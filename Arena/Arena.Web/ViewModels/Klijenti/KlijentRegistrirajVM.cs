using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Arena.Web.ViewModels.Klijenti
{
    public class KlijentRegistrirajVM
    {
        [Required(ErrorMessage = "Ime je obavezno.")]
        [Display(Name = "Ime", Prompt ="Upišite ime")]
        public string Ime { get; set; }
     
        [Required(ErrorMessage = "Prezime je obavezno.")]
        [Display(Name = "Prezime", Prompt = "Upišite prezime")]
        public string Prezime { get; set; }
     
        [Required(ErrorMessage = "Spol je obavezan.")]
        [Display(Name = "Spol", Prompt = "Upišite spol")]
        public string Spol { get; set; }
        
        
        [Required(ErrorMessage = "JBMG je obavezan.")]
        [Display(Name = "JBMG", Prompt = "Upišite JBMG")]
        public string JBMG { get; set; }



        [Required(ErrorMessage = "Username je obavezan.")]
        [Display(Name = "Username", Prompt = "Upišite Username")]
        public string Username { get; set; }


        [Required(ErrorMessage = "Password je obavezan.")]
        [Display(Name = "Password", Prompt = "Upišite Password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        public int OdabraniGradId { get; set; }
        public List<SelectListItem> Gradovi { get; set; }
    }
}
