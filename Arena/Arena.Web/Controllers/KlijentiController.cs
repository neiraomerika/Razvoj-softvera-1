using Arena.EF;
using Arena.Models;
using Arena.Web.ViewModels.Klijenti;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Arena.Web.Controllers
{
    public class KlijentiController :Controller
    {

        private MojDbContext context;
        private UserManager<Nalog> userManager;
        private SignInManager<Nalog> signInManager;
        public KlijentiController(MojDbContext context, UserManager<Nalog> userManager, SignInManager<Nalog> signInManager)
        {
            this.context = context;
            this.userManager = userManager;
            this.signInManager = signInManager;
        }

        [HttpGet]
        public IActionResult Registriraj()
        {

            var model = new KlijentRegistrirajVM();
           
            model.Gradovi = GetGradoviDropdown();
            return View("Registriraj", model);
        }

        [HttpPost]
        public async Task<IActionResult> Registriraj(KlijentRegistrirajVM model)
        {

            if(!ModelState.IsValid)
            {
                model.Gradovi = GetGradoviDropdown();
                return View("Registriraj", model);
            }


            var pwValidaton = new PasswordValidator<Nalog>();
            var validationResult =  await pwValidaton
                .ValidateAsync(userManager, null, model.Password);
            if (!validationResult.Succeeded)
            {

                foreach (var item in validationResult.Errors.Select(x=>x.Description))
                {
                    ModelState.AddModelError("", item);
                }
                model.Gradovi = GetGradoviDropdown();
                return View("Registriraj", model);

            }


            var postojeciKorisnik = await userManager.FindByNameAsync(model.Username);
            if (postojeciKorisnik != null)
            {
                ModelState.AddModelError("", "Korisnicko ime je zauzeto.");
                model.Gradovi = GetGradoviDropdown();
                return View("Registriraj", model);
            }

            var noviNalog = new Nalog
            {
                UserName = model.Username,
                IsKlijent = true
            };

            await userManager.CreateAsync(noviNalog, model.Password);


            Klijent klijent = new Klijent
            {
                Ime = model.Ime,
                Prezime = model.Prezime,
                GradID = model.OdabraniGradId,
                JBMG = model.JBMG,
                UserId = noviNalog.Id,
                Spol = model.Spol
            };

            context.Add(klijent);
            context.SaveChanges();




            await signInManager.SignInAsync(noviNalog, true);

            return RedirectToAction("Index","Home" );
        }

        private List<SelectListItem> GetGradoviDropdown()
        {
          return  context.Gradovi
                .OrderBy(x => x.Naziv)
                .Select(x => new SelectListItem
                {

                    Text = x.Naziv,
                    Value = x.ID.ToString()
                })
                .ToList();
        }
    }
}
