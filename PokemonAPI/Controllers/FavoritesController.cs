using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PokemonAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace PokemonAPI.Controllers
{
    [Authorize]
    public class FavoritesController : Controller
    {
        private readonly PokemonAPIContext _context;
        public PokemonapiDAL DAL = new PokemonapiDAL();

        public FavoritesController(PokemonAPIContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var model = new FavoritePokemonViewModel();

            var userId = User.FindFirst(ClaimTypes.NameIdentifier).Value;

            model.Favorites = _context.Favorites.Where(x => x.UserId == userId).ToList();
            // // //


            foreach (Favorites fav in model.Favorites)
            {
                model.Pokemon.Add(DAL.ConvertToPokemonModelsFav(fav.PokedexNumber));
            }
            // // //
            return View(model);
        }
    

        // Create View Form
        [HttpGet]
        public IActionResult AddToFavorites()
        {
            return View(new Favorites());
        }

        // Create Add
        [HttpPost]
        public IActionResult AddToFavorites(Favorites favorites)
        {
            if (ModelState.IsValid)
            {

                favorites.UserId = User.FindFirst(ClaimTypes.NameIdentifier).Value;

                // Add to the database
                _context.Favorites.Add(favorites);

                // Save changes to database
                _context.SaveChanges();

                return RedirectToAction(nameof(Index));
            }

            return RedirectToAction(nameof(AddToFavorites), favorites);
        }
 
        public IActionResult RemoveFromFavorites(int id)
        {
            Favorites f = _context.Favorites.Find(id);

            _context.Favorites.Remove(f);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}
