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

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Search()
        {
            return View();
        }

        public IActionResult SearchResults(string Name, int Id)
        {
                if (!string.IsNullOrWhiteSpace(Name))
                {
                    try
                    {
                        string search = Name;
                        SearchBy typeOfSearch = SearchBy.name;
                        Pokemon p = DAL.ConvertToPokemonModels(search, typeOfSearch);
                        return View(p);
                    }
                    catch
                    {
                        return View("Search");
                    }
                }
                else if (Id != 0)
                {
                    string search = Id.ToString();
                    SearchBy typeOfSearch = SearchBy.id;
                    Pokemon p = DAL.ConvertToPokemonModels(search, typeOfSearch);
                    return View(p);
                }
                return View("");
        }
        public IActionResult SearchType(string types)
        {
            List<Pokemon> selection = new List<Pokemon> { };

            string search = types;
            SearchBy typeOfSearch = SearchBy.type;
            selection = DAL.ConvertTypeToPokemonModels(search, typeOfSearch);

            string type = $"{search.Substring(0, 1).ToUpper()}{search.Substring(1)}";
            ViewBag.Type = type;
            return View(selection);
        }
        // // // 
        public IActionResult PokemonFav(int id)
        {
            Pokemon p = DAL.ConvertToPokemonModelsFav(id);
            return View(p);
        }
        // // //
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
