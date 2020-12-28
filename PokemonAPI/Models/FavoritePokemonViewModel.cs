using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PokemonAPI.Models
{
    public class FavoritePokemonViewModel
    {
        public List<Favorites> Favorites { get; set; } = new List<Favorites>();
        public List<Pokemon> Pokemon { get; set; } = new List<Pokemon>();

    }
}
