using LaboBadge.Models;
using System.Text;
using System.Text.Json;

namespace LaboBadge.Services
{
    public static class UserServices
    {
        private static readonly HttpClient _httpClient = new HttpClient();
        

        public static async Task Signin(string email, string passwd)
        {
            User user = new User()
            {
                Email = email,
                Passwd = passwd,
                Rule = "user"
            };
            HttpContent content = null;
            var json = JsonSerializer.Serialize(user);
            var data = new StringContent(json,Encoding.UTF8,"application/json");
            try
            {
                Console.WriteLine(data);
                HttpResponseMessage response = await _httpClient.PostAsync("Https://localhost:10000/User/", data);
                string responseBody = await response.Content.ReadAsStringAsync();
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
