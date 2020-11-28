using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace PokemonAPI.Models
{
    public class PokemonapiDAL
    {
        public string GetPokemon(int id)
        {
            string endpoint = $"https://pokeapi.co/api/v2/pokemon/{id}";

            HttpWebRequest request = WebRequest.CreateHttp(endpoint);

            HttpWebResponse response = (HttpWebResponse)request.GetResponse();

            StreamReader rd = new StreamReader(response.GetResponseStream());

            string output = rd.ReadToEnd();

            return output;

        }

        public Pokemon ConvertToPokemonModels(int id)
        {
            string pokemonData = GetPokemon(id);
            Pokemon p = JsonConvert.DeserializeObject<Pokemon>(pokemonData);

            return p;

        }


    }
}
