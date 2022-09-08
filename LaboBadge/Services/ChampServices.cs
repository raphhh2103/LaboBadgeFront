using LaboBadge.Models;
using System.Net.Http.Headers;
using System.Net.Http.Json;

namespace LaboBadge.Services
{
    public class ChampServices
    {
        private readonly HttpClient _httpClient = new HttpClient();

        public async Task<Champ[]> GetAllChamp(string token)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            Champ[]? champs;
            champs = await _httpClient.GetFromJsonAsync<Champ[]>("https://localhost:10000/Champ");
            foreach (var item in champs)
            {
                Console.WriteLine(item.BasicStatisticId +" idddddddddddddddddddddddddddddd");
                //foreach (var item2 in item.Skills)
                //{
                //    Console.WriteLine(item2.Name);  
                //}
            }

            return champs;
        }
        public async Task WaitAndSee()
        {
             Task.Delay(3000);

            /*yield return*/ /*null*/;
        }
    }
}
