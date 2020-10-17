using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Arena.Web.Models;
using Microsoft.AspNetCore.Authorization;
using Arena.Web.ViewModels.Dashboard;
using Arena.EF;

namespace Arena.Web.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly MojDbContext context;
        public HomeController(ILogger<HomeController> logger, MojDbContext context)
        {
            _logger = logger;
            this.context = context;
        }
        public IActionResult Index()
        {
            var model = new DashboardVM();
            model.EmployeesCount = context.Nalozi.Where(x => x.IsUposlenik == true).Count();
            model.ClientsCount = context.Nalozi.Where(x => x.IsKlijent== true).Count();
            model.AppointmentsCount = context.Termini.Count();
            return View(model);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
