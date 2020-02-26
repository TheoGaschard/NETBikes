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

            return View(Stations);
        }

        public async Task<IActionResult> Carte()
        {
            var Stations = await Traitement.FindStations();
            var StationsBdx = await Traitement.FindStationsBdx();

            var ResultBdx = new List<Station>();
            foreach (var stationBdx in StationsBdx)
            {
                var construit = new Station(stationBdx);
                ResultBdx.Add(construit);
            }

            Stations.AddRange(ResultBdx);


            return View(Stations);
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
