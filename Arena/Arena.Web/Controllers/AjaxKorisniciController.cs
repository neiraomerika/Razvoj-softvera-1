using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Arena.EF;
using Arena.Models;
using Arena.Web.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Arena.Web.Controllers
{
    public class AjaxKorisniciController : Controller
    {
        private MojDbContext db;

        public AjaxKorisniciController(MojDbContext db)
        {
            this.db = db;
        }


        public IActionResult Administratori()
        {
            AjaxAdministratoriVM Model = new AjaxAdministratoriVM();

            Model.admini = db.Administratori.Select(s => new AjaxAdministratoriVM.admins
            {
                Username = s.User.UserName,
                Ime = s.Ime,
                Prezime = s.Prezime
            }).ToList();

            return View(Model);

        }


        public IActionResult DodajAdministratora()
        {
            return View();
        }


        public IActionResult Klijenti()
        {
            AjaxKlijentiVM Model = new AjaxKlijentiVM()
            {
                klijenti = db.Klijenti.Select(s => new AjaxKlijentiVM.klijent
                {
                    ID = s.ID,
                    Username = s.User.UserName,
                    Ime = s.Ime,
                    Prezime = s.Prezime,
                    JMBG = s.JBMG,
                    Spol = s.Spol,
                    Grad = s.Grad.Naziv


                }).ToList()
            };
            return View(Model);

        }

        public IActionResult DodajKlijenta()
        {
            AjaxDodajKlijentaVM Model = new AjaxDodajKlijentaVM()
            {
                gradovi = db.Gradovi.Select(s => new SelectListItem
                {
                    Text = s.Naziv,
                    Value = s.ID.ToString()
                }).ToList()
            };
            return View(Model);
        }

        public IActionResult UrediKlijenta(int id)
        {
            AjaxKorisniciUrediKlijentaVM Model = db.Klijenti.Where(w => w.ID == id).
                Select(s => new AjaxKorisniciUrediKlijentaVM
                {
                    ID = s.ID,
                    Ime = s.Ime,
                    Prezime = s.Prezime,
                    Username = s.User.UserName,
                    Spol = s.Spol,
                    JMBG = s.JBMG,

                    Gradovi = db.Gradovi.Select(s => new SelectListItem
                    {
                        Text = s.Naziv,
                        Value = s.ID.ToString()
                    }).ToList()

                }).FirstOrDefault();
            return View(Model);
        }

        public IActionResult SnimiKlijenta(
            int id,string username,string lozinka,string ime,string prezime,
            string spol,string jmbg,string grad)
        {
            Klijent k = db.Klijenti.Where(w => w.ID == id).Include(g => g.Grad).Include(n => n.User).FirstOrDefault();

            k.User.UserName = username;
            k.Ime = ime;
            k.Prezime = prezime;
            k.Spol = spol;
            k.JBMG = jmbg;
            k.GradID = int.Parse(grad);

            db.SaveChanges();
            return Redirect("Klijenti");

        }

        public IActionResult ObrisiKlijenta(int id)
        {
            Klijent k = db.Klijenti.Where(w => w.ID == id).Include(n => n.User).First();

            db.Nalozi.Remove(k.User);
            db.Klijenti.Remove(k);

            db.SaveChanges();

            return Redirect("Klijenti");
        }
    }
}