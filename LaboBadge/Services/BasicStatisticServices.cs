using LaboBadge.Models;
using System.Net.Http.Headers;
using System.Net.Http.Json;

namespace LaboBadge.Services
{
    public class BasicStatisticServices
    {
        private readonly HttpClient _httpClient= new HttpClient();

        public async Task<BasicStatistic> GetOne(string token, int id)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            BasicStatistic? basic;
            basic = await _httpClient.GetFromJsonAsync<BasicStatistic>($"https://localhost:10000/BasicStat/id?id={id}");
            Console.WriteLine(id+" idddddddddddddddddddddddddddddddddddddddddddd stat");
            return basic;
        
        }
    }
}
