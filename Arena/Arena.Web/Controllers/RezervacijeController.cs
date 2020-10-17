using Arena.EF;
using Arena.Models;
using Arena.Web.ViewModels.Rezervacije;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Arena.Web.Controllers
{
    public class RezervacijeController : Controller
    {
        private MojDbContext context;

        public RezervacijeController(MojDbContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var model = new RezervacijePretragaVM();
            model.Dvorane = GetDvorane();


            model.RezultatPretrage = context.Rezervacije
            .OrderByDescending(x => x.Termin.DatumIVrijeme)
            .Select(x => new RezervacijeIndexVM()
            {
                ID = x.ID,
                TerminID = x.TerminID,
                DatumIVrijemeTermina = x.Termin.DatumIVrijeme,
                Ime = x.Klijent.Ime,
                Prezime = x.Klijent.Prezime,
                NazivDvorane = x.Termin.Dvorana.Naziv,
                OdobrenaRezervacija = x.OdobrenaRezervacija,
                Placeno = x.UplataID != null
            })
            .ToList();
            return View(model);
        }

        [HttpPost]
        public IActionResult Pretraga(RezervacijePretragaVM model)
        {
            model.Dvorane = GetDvorane();

            var imeLowercase = model.ImeKlijenta?.ToLower();
            var prezimeLowercase = model.PrezimeKlijenta?.ToLower();

            model.RezultatPretrage = context.Rezervacije
            .OrderByDescending(x => x.Termin.DatumIVrijeme)
            .Where(x => model.OdabranaDvorana == null || x.Termin.DvoranaID == model.OdabranaDvorana)
            .Where(x => string.IsNullOrEmpty(imeLowercase) || x.Klijent.Ime.ToLower().Contains(imeLowercase))
            .Where(x => string.IsNullOrEmpty(prezimeLowercase) || x.Klijent.Prezime.ToLower().Contains(prezimeLowercase))
            .Select(x => new RezervacijeIndexVM()
            {
                ID = x.ID,
                TerminID = x.TerminID,
                DatumIVrijemeTermina = x.Termin.DatumIVrijeme,
                Ime = x.Klijent.Ime,
                Prezime = x.Klijent.Prezime,
                NazivDvorane = x.Termin.Dvorana.Naziv,
                OdobrenaRezervacija = x.OdobrenaRezervacija,
                Placeno = x.UplataID != null
            })
            .ToList();
            return View("Index", model);

        }


        [HttpGet]
        public IActionResult Dodaj()
        {
            var model = new RezervacijaDodajVM();
            model.Termini = GetTermini();
            model.Klijenti = GetKlijenti();
            return View("Dodaj", model);
        }

        [HttpPost]
        public IActionResult Dodaj(RezervacijaDodajVM model)
        {
            if (!ModelState.IsValid)
            {
                model.Termini = GetTermini();
                model.Klijenti = GetKlijenti();
                return View("Dodaj", model);
            }

            var novaRezervacija = new Rezervacija
            {
                KlijentID = model.OdabraniKlijentId.Value,
                OdobrenaRezervacija=false,
                TerminID= model.OdabraniTerminId.Value,
                UplataID= null
            };

            context.Rezervacije.Add(novaRezervacija);
            context.SaveChanges();

            return RedirectToAction("Index");
        }



        [HttpGet]
        public IActionResult Edit(int id)
        {
            var rezervacija = context.Rezervacije.FirstOrDefault(x => x.ID == id);

            var model = new RezervacijaEditVM();
            model.Termini = GetTermini();
            model.Klijenti = GetKlijenti();

            model.ID = rezervacija.ID;
            model.OdabraniKlijentId = rezervacija.KlijentID;
            model.OdabraniTerminId = rezervacija.TerminID;
            model.OdobrenaRezervacija = rezervacija.OdobrenaRezervacija;

            return View("Edit", model);
        }

        [HttpPost]
        public IActionResult Edit(int id, RezervacijaEditVM model)
        {
            if (!ModelState.IsValid)
            {
                model.Termini = GetTermini();
                model.Klijenti = GetKlijenti();
                return View("Edit", model);
            }
            var rezervacija = context.Rezervacije.FirstOrDefault(x => x.ID == id);

            rezervacija.KlijentID = model.OdabraniKlijentId.Value;
            rezervacija.TerminID = model.OdabraniTerminId.Value;
            rezervacija.OdobrenaRezervacija = model.OdobrenaRezervacija;

            context.Rezervacije.Update(rezervacija);
            context.SaveChanges();

            return RedirectToAction("Index");
        }


        private List<SelectListItem> GetKlijenti()
        {
            var dostupniKlijenti = context.Klijenti
                        .Select(x => new SelectListItem
                        {
                            Text = x.Ime + " " + x.Prezime + " " + x.JBMG,
                            Value = x.ID.ToString()
                        }).ToList();


            dostupniKlijenti.Insert(0, new SelectListItem
            {
                Text = "--Odaberite klijenta--",
                Value = null
            });
            return dostupniKlijenti;
        }

        private List<SelectListItem> GetTermini()
        {
            var dostupniTermini = context.Termini
                .Select(x => new SelectListItem
                {
                    Text = x.DatumIVrijeme.ToString("dd.MM.yyyy HH:mm") + " - " + x.Dvorana.Naziv,
                    Value = x.ID.ToString()
                }).ToList();


            dostupniTermini.Insert(0, new SelectListItem
            {
                Text = "--Odaberite termin--",
                Value = null
            });
            return dostupniTermini;
        }

        private List<SelectListItem> GetDvorane()
        {
            var dostupneDvorane = context.Dvorana.Select(x => new SelectListItem
            {
                Text = x.Naziv,
                Value = x.ID.ToString()
            }).ToList();
            dostupneDvorane.Insert(0, new SelectListItem
            {
                Text = "--Odaberite dvoranu--",
                Value = null
            });
            return dostupneDvorane;
        }
    }
}
