using LaboBadge.Models;
using LaboBadge.Pages;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Text.Json.Nodes;

namespace LaboBadge.Services
{
    public class EquipmentServices
    {
        private readonly HttpClient _httpClient = new HttpClient();

        public async Task<EquipmentModels[]> GetAllEquipment(string token)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            EquipmentModels[]? equipmentModels ;
            //var content = await _httpClient.
            //    GetFromJsonAsync<EquipmentModels[]>("https://localhost:10000/Equipment");
            equipmentModels = await _httpClient.GetFromJsonAsync<EquipmentModels[]>("https://localhost:10000/Equipment");

            //EquipmentModels[] equipmentList = content;
            HttpRequestMessage requestMessage = new HttpRequestMessage()
            {
                Method = new HttpMethod("GET"),
                RequestUri = new Uri("Https://LocalHost:10000/Equipment"),
                

            };
            requestMessage.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);
             var result = await _httpClient.SendAsync(requestMessage);
            foreach (var item in equipmentModels)
            {

            //Console.WriteLine(item.Effect);
            //Console.WriteLine(result.Content+" contennnnnnnnnnnnntttttttttt");
            }
            return equipmentModels;
        }
        public async Task CreatingEquipment(EquipmentModels models,string token)
        {
            var json = JsonSerializer.Serialize(models);
            var data = new StringContent(json, Encoding.UTF8, "application/json");
            HttpRequestMessage requestMessage = new HttpRequestMessage()
            {
                Method =  new HttpMethod("POST"),
                RequestUri = new Uri("https://localhost:10000/Equipment"),
                Content = data
            };
            requestMessage.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var result = await _httpClient.SendAsync(requestMessage);
            //var result = await _httpClient.PostAsJsonAsync("https://localhost:10000/Equipment", data );


            Console.WriteLine(result);
            //return result;
        }

    }
}
