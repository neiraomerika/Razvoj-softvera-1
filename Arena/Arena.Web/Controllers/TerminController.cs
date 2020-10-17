using Arena.EF;
using Arena.Models;
using Arena.Web.ViewModels.Termini;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Arena.Web.Controllers
{
    public class TerminController : Controller
    {
        private readonly MojDbContext context;

        public TerminController(MojDbContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var model = new TerminPretragaVM
            {

            };

            model.Dvorane = GetDvorane();


            model.RezultatPretrage = context.Termini
                .OrderByDescending(x=>x.DatumIVrijeme)
                 .Select(x => new TerminIndexVM
                 {
                     Cijena = x.Cijena,
                     Datum = x.DatumIVrijeme,
                     Id = x.ID,
                     NazivDvorane = x.Dvorana.Naziv
                 })
                 .ToList();
            return View(model);

        }

        [HttpPost]
        public IActionResult Pretraga(TerminPretragaVM model)
        {
            model.Dvorane = GetDvorane();
            model.RezultatPretrage = context.Termini

                .Where(x=> model.DvoranaId==null || x.DvoranaID==model.DvoranaId)
                .OrderByDescending(x=>x.DatumIVrijeme)
                 .Select(x => new TerminIndexVM
                 {
                     Cijena = x.Cijena,
                     Datum = x.DatumIVrijeme,
                     Id = x.ID,
                     NazivDvorane = x.Dvorana.Naziv
                 })
                 .ToList();
            return View("Index",model);

        }


        [HttpGet]
        public IActionResult Dodaj()
        {
            var model = new TerminDodajVM();
            model.Dvorane = GetDvorane();
            model.DatumIVrijeme = DateTime.Now;
            return View("Dodaj", model);
        }

        [HttpPost]
        public IActionResult Dodaj(TerminDodajVM model)
        {
            if(!ModelState.IsValid)
            {
                model.Dvorane = GetDvorane();
                return View("Dodaj", model);    
            }

            var noviTermin = new Termin
            {
                Cijena = model.Cijena,
                DatumIVrijeme = model.DatumIVrijeme,
                DvoranaID = model.OdabranaDvoranaId,
            };

            context.Termini.Add(noviTermin);
            context.SaveChanges();

            return RedirectToAction("Index");
        }


        [HttpGet]
        public IActionResult Edit(int id)
        {
            var model = new TerminEditVM();
            model.Dvorane = GetDvorane();

            var zapisIzBaze = context.Termini.Where(x => x.ID == id)
                .FirstOrDefault();

            if (zapisIzBaze == null)
                return NotFound();

            model.Id = zapisIzBaze.ID;
            model.DatumIVrijeme = zapisIzBaze.DatumIVrijeme;
            model.OdabranaDvoranaId = zapisIzBaze.DvoranaID;
            model.Cijena = zapisIzBaze.Cijena;

            return View("Edit", model);
        }


        [HttpPost]
        public IActionResult Edit(int id, TerminEditVM model)
        {
            if (!ModelState.IsValid)
            {
                model.Dvorane = GetDvorane();
                return View("Edit", model);
            }

            var zapisIzBaze = context.Termini.Where(x => x.ID == id)
                .FirstOrDefault();

            if (zapisIzBaze == null)
                return NotFound();

            zapisIzBaze.Cijena = model.Cijena;
            zapisIzBaze.DatumIVrijeme = model.DatumIVrijeme;
            zapisIzBaze.DvoranaID = model.OdabranaDvoranaId;


            context.Termini.Update(zapisIzBaze);
            context.SaveChanges();


            return RedirectToAction("Index");
        }


        private List<SelectListItem> GetDvorane()
        {
            var items = context.Dvorana
                .OrderBy(x => x.Naziv)
                .Select(x => new SelectListItem
                {
                    Text = x.Naziv,
                    Value = x.ID.ToString()
                })
                .ToList();

            items.Insert(0, new SelectListItem
            {
                Value = null,
                Text = "Odaberite dvoranu"
            });

            return items;
        }
    }
}
