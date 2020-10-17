using Arena.EF;
using Arena.Models;
using Arena.Web.ViewModels;
using Arena.Web.ViewModels.Korisnici;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Arena.Web.Controllers
{
    public class KorisniciController : Controller
    {
        private MojDbContext db;
        private UserManager<Nalog> userManager;
        public KorisniciController(MojDbContext db, UserManager<Nalog> userManager)
        {
            this.db = db;
            this.userManager = userManager;
        }
        [HttpGet]
        public IActionResult Index()
        {

            var model = new KorisnikPretragaVM { };

            var administratori = db.Administratori
                .Include(x => x.User)
                .Select(x => new KorisnikIndexVM
                {
                    Ime = x.Ime,
                    Prezime = x.Prezime,
                    IsAdministrator = true,
                    Grad = "",
                    ID = x.ID,
                    IsKlijent = false,
                    IsUposlenik = false,
                    JMBG = "",
                    Spol = "",
                    Username = x.User.UserName
                }).ToList();

            var klijenti = db.Klijenti
                .Include(x => x.User)
               .Select(x => new KorisnikIndexVM
               {
                   Ime = x.Ime,
                   Prezime = x.Prezime,
                   IsAdministrator = false,
                   Grad = x.Grad.Naziv,
                   ID = x.ID,
                   IsKlijent = true,
                   IsUposlenik = false,
                   JMBG = x.JBMG,
                   Spol = x.Spol,
                   Username = x.User.UserName
               }).ToList();


            var uposlenici = db.Uposlenici
                .Include(x => x.User)
              .Select(x => new KorisnikIndexVM
              {
                  Ime = x.Ime,
                  Prezime = x.Prezime,
                  IsAdministrator = false,
                  Grad = x.Grad.Naziv,
                  ID = x.ID,
                  IsKlijent = false,
                  IsUposlenik = true,
                  JMBG = "",
                  Spol = "",
                  Username = x.User.UserName
              }).ToList();



            model.RezultatPretrage = administratori;
            model.RezultatPretrage.AddRange(klijenti);
            model.RezultatPretrage.AddRange(uposlenici);

            model.RezultatPretrage = model.RezultatPretrage.OrderBy(x => x.Username).ToList();

            return View(model);
        }

        [HttpPost]
        public IActionResult Pretraga(KorisnikPretragaVM model)
        {
            var loweredUsername = model.Username?.ToLower();
            var administratori = db.Administratori
                .Include(x => x.User)
                .Where(x => string.IsNullOrEmpty(loweredUsername) || x.User.UserName.ToLower().Contains(loweredUsername))
                .Select(x => new KorisnikIndexVM
                {
                    Ime = x.Ime,
                    Prezime = x.Prezime,
                    IsAdministrator = true,
                    Grad = "",
                    ID = x.ID,
                    IsKlijent = false,
                    IsUposlenik = false,
                    JMBG = "",
                    Spol = "",
                    Username = x.User.UserName
                }).ToList();

            var klijenti = db.Klijenti
                .Include(x => x.User)
                .Where(x => string.IsNullOrEmpty(loweredUsername) || x.User.UserName.ToLower().Contains(loweredUsername))
               .Select(x => new KorisnikIndexVM
               {
                   Ime = x.Ime,
                   Prezime = x.Prezime,
                   IsAdministrator = false,
                   Grad = x.Grad.Naziv,
                   ID = x.ID,
                   IsKlijent = true,
                   IsUposlenik = false,
                   JMBG = x.JBMG,
                   Spol = x.Spol,
                   Username = x.User.UserName
               }).ToList();


            var uposlenici = db.Uposlenici
                .Include(x => x.User)
                .Where(x => string.IsNullOrEmpty(loweredUsername) || x.User.UserName.ToLower().Contains(loweredUsername))
              .Select(x => new KorisnikIndexVM
              {
                  Ime = x.Ime,
                  Prezime = x.Prezime,
                  IsAdministrator = false,
                  Grad = x.Grad.Naziv,
                  ID = x.ID,
                  IsKlijent = false,
                  IsUposlenik = true,
                  JMBG = "",
                  Spol = "",
                  Username = x.User.UserName
              }).ToList();



            model.RezultatPretrage = administratori;
            model.RezultatPretrage.AddRange(klijenti);
            model.RezultatPretrage.AddRange(uposlenici);

            model.RezultatPretrage = model.RezultatPretrage.OrderBy(x => x.Username).ToList();

            return View("Index", model);
        }


        [HttpGet]
        public IActionResult DodajUposlenik()
        {
            var model = new KorisnikZaposlenikDodajVM();

            model.Gradovi = GetGradovi();
            model.Plate = GetPlate();
            model.TipoviUposlenika = GetTipoviUposlenika();


            return View("DodajUposlenik", model);
        }
        [HttpPost]
        public async Task<IActionResult> DodajUposlenik(KorisnikZaposlenikDodajVM model)
        {
            if (!ModelState.IsValid)
            {
                model.Gradovi = GetGradovi();
                model.Plate = GetPlate();
                model.TipoviUposlenika = GetTipoviUposlenika();
                return View("DodajUposlenik", model);
            }

            var nalog = new Nalog
            {
                Id = Guid.NewGuid().ToString(),
                UserName = model.Username,
                IsUposlenik = true
            };
            await userManager.CreateAsync(nalog, model.Password);

            var noviZaposlenik = new Uposlenik
            {
                BrojTelefona = model.BrojTelefona,
                GradID = model.GradID.Value,
                Ime = model.Ime,
                Prezime = model.Prezime,
                PlataID = model.PlataID.Value,
                TipUposlenikaID = model.TipUposlenikaID.Value,
                UserId = nalog.Id
            };

            db.Uposlenici.Add(noviZaposlenik);
            db.SaveChanges();

            return RedirectToAction("Index");
        }
        private List<SelectListItem> GetTipoviUposlenika()
        {
            var items = db.TipoviUposlenika
                           .Select(x => new SelectListItem
                           {
                               Text = x.Naziv,
                               Value = x.ID.ToString()
                           }).ToList();


            items.Insert(0, new SelectListItem
            {
                Text = "--Odaberite--",
                Value = null
            });
            return items;
        }

        private List<SelectListItem> GetPlate()
        {
            var items = db.Plate
                .Select(x => new SelectListItem
                {
                    Text = x.Iznos.ToString() + "",
                    Value = x.ID.ToString()
                }).ToList();


            items.Insert(0, new SelectListItem
            {
                Text = "--Odaberite--",
                Value = null
            });
            //return items.Select(x => new SelectListItem
            //{
            //    Text = x.Iznos + "KM",
            //    Value = x.ID.ToString()
            //}).ToList();
            return items;
        }

        private List<SelectListItem> GetGradovi()
        {
            var items = db.Gradovi
                                  .Select(x => new SelectListItem
                                  {
                                      Text = x.Naziv,
                                      Value = x.ID.ToString()
                                  }).ToList();


            items.Insert(0, new SelectListItem
            {
                Text = "--Odaberite--",
                Value = null
            });
            return items;
        }
    }
}
