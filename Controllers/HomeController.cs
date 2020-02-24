using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using BikeWatcher.Models;

namespace BikeWatcher.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Acceuil()
        {
            return View();
        }

        public async Task<IActionResult> Liste()
        {

            var Stations = await Traitement.FindStations();
            ViewBag.AllBikeStations = Stations;
            
            return View();
        }

        public IActionResult Carte()
        {
            return View();
        }

        public IActionResult Favoris()
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
