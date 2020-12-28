using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace PokemonAPI.Models
{
    public enum SearchBy
    {
        name,
        id,
        type
    }
    public class PokemonapiDAL
    {
        public string GetPokemon(string search, SearchBy typeOfSearch)
        {
            switch (typeOfSearch)
            {
                case SearchBy.id:
                    int.TryParse(search, out int id);

                    string endpointId = $"https://pokeapi.co/api/v2/pokemon/{id}/";

                    HttpWebRequest requestId = WebRequest.CreateHttp(endpointId);

                    HttpWebResponse responseId = (HttpWebResponse)requestId.GetResponse();

                    StreamReader rdId = new StreamReader(responseId.GetResponseStream());

                    string outputId = rdId.ReadToEnd();

                    return outputId;

                case SearchBy.name:
                    string name = search.ToLower();

                    string endpointName = $"https://pokeapi.co/api/v2/pokemon/{name}/";

                    HttpWebRequest requestName = WebRequest.CreateHttp(endpointName);

                    HttpWebResponse responseName = (HttpWebResponse)requestName.GetResponse();

                    StreamReader rdName = new StreamReader(responseName.GetResponseStream());

                    string outputName = rdName.ReadToEnd();

                    return outputName;

                case SearchBy.type:
                    string type = search;

                    string endpoint = $"https://pokeapi.co/api/v2/type/{type}/";

                    HttpWebRequest requestT = WebRequest.CreateHttp(endpoint);

                    HttpWebResponse responseT = (HttpWebResponse)requestT.GetResponse();

                    StreamReader rdT = new StreamReader(responseT.GetResponseStream());

                    string outputType = rdT.ReadToEnd();

                    return outputType;
            }
            return "";
        }

        public Pokemon ConvertToPokemonModels(string search, SearchBy typeOfSearch)
        {
            string pokemonData = GetPokemon(search, typeOfSearch);
            Pokemon p = JsonConvert.DeserializeObject<Pokemon>(pokemonData);

            return p;
        }
        public List<Pokemon> ConvertTypeToPokemonModels(string search, SearchBy typeOfSearch)
        {
            string pokemonData = GetPokemon(search, typeOfSearch);
            List<Pokemon> p = new List<Pokemon> { };
            var pokeResult = JsonConvert.DeserializeObject<PokemonListResult>(pokemonData);
            int count = 0;

            foreach (var thisPokemon in pokeResult.Pokemon)
            {
                count++;
                var pokemon = GetPokemon(thisPokemon.Pokemon.name, SearchBy.name);
                var deserializedPokemon = JsonConvert.DeserializeObject<Pokemon>(pokemon);
                p.Add(deserializedPokemon);

                if (count >= 10) break;
            }
            return p;
        }
        // // //
        public string GetFavPokemon(int id)
        {
            string endpoint = $"https://pokeapi.co/api/v2/pokemon/{id}";

            HttpWebRequest request = WebRequest.CreateHttp(endpoint);

            HttpWebResponse response = (HttpWebResponse)request.GetResponse();

            StreamReader rd = new StreamReader(response.GetResponseStream());

            string output = rd.ReadToEnd();

            return output;

        }
      
        
       
        public Pokemon ConvertToPokemonModelsFav(int id)
        {
            string pokemonData = GetFavPokemon(id);
            Pokemon p = JsonConvert.DeserializeObject<Pokemon>(pokemonData);

            return p;

        }
        ////////

    }
}
