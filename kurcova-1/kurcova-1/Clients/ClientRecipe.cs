using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using kurcova_1.Models;

namespace kurcova_1.Clients
{
    public class ClientRecipe
    {

        public static async Task<List<Recipe>> GetRecipes(string dish)
        {
            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri($"https://localhost:7167/Recipe?dish={dish}"),
                Headers =
            {
                { "X-RapidAPI-Key", "34d7f3c379mshf511c2d5acb645fp1ddca2jsn939b03ca067e" },
                { "X-RapidAPI-Host", "recipe-by-api-ninjas.p.rapidapi.com" },
            },
            };

            using (var response = await client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var json = await response.Content.ReadAsStringAsync();
                List<Recipe> recipes = JsonConvert.DeserializeObject<List<Recipe>>(json);
                return recipes;
            }
        }


    }
}
