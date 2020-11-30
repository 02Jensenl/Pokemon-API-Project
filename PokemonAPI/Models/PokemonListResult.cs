using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PokemonAPI.Models
{
    public class PokeSingleResult
    {
        public Pokemon Pokemon { get; set; }
    }
    public class PokemonListResult
    {
        public List<PokeSingleResult> Pokemon { get; set; }
    }
}
