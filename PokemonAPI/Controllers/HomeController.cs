using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PokemonAPI.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace PokemonAPI.Controllers
{
    public class HomeController : Controller
    {
        public PokemonapiDAL DAL = new PokemonapiDAL();

        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Pokemon(int id)
        {
            Pokemon p = DAL.ConvertToPokemonModels(id);
            return View(p);
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
