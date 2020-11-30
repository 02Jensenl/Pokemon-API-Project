using System;
using System.Collections.Generic;

namespace PokemonAPI.Models
{
    public partial class Favorites
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public int Weight { get; set; }
        public int Height { get; set; }
        public int PokedexNumber { get; set; }
        public string UserId { get; set; }

        public virtual AspNetUsers User { get; set; }
    }
}
