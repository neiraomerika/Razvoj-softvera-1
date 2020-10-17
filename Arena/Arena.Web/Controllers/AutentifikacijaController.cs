using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Arena.EF;
using Arena.Models;
using Arena.Web.Helper;
using Arena.Web.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Arena.Web.Controllers
{
    public class AutentifikacijaController : Controller
    {
        private MojDbContext db;
        private readonly SignInManager<Nalog> signInManager;
        private readonly UserManager<Nalog> userManager;
        private IHttpContextAccessor httpContext;

        public AutentifikacijaController(MojDbContext db, IHttpContextAccessor httpContext, SignInManager<Nalog> signInManager, UserManager<Nalog> userManager)
        {
            this.db = db;
            this.httpContext = httpContext;
            this.signInManager = signInManager;
            this.userManager = userManager;
        }

        public IActionResult Prijava()
        {
            return View(new LoginVM());
        }

        [HttpPost]
        public async Task<IActionResult> Prijava(LoginVM login)
        {

            if (!ModelState.IsValid)
            {
                return View(login);
            }

            //pronadjemo korisnika iz baze po korisnickom imenu
            var user = await userManager.FindByNameAsync(login.Username);
            if (user == null)
            {
                ModelState.AddModelError("","Neispravna lozinka ili kor. ime.");
                return View(login);
            }

            var signInResult = await signInManager.CheckPasswordSignInAsync(user, login.Password, false);
            if (!signInResult.Succeeded)
            {
                ModelState.AddModelError("", "Neispravna lozinka ili kor. ime.");
                return View(login);
            }

            await signInManager.SignInAsync(user, login.ZapamtiPassword);
            return RedirectToAction("Index","Home");
        }

        public async Task<IActionResult> Odjava()
        {
            await signInManager.SignOutAsync();
            //Autentifikacija.OcistiSesiju(httpContext.HttpContext);
            return RedirectToAction("Prijava");
        }
    }
}