using LaboBadge.Models;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using LaboBadge.Mapper;
using Microsoft.AspNetCore.Components.WebAssembly;
using Microsoft.AspNetCore.Components.WebAssembly.Authentication;
using System.Net.Http.Headers;
using LaboBadge.Storage;
using Microsoft.JSInterop;

namespace LaboBadge.Services
{
    public  class UserServices
    {
        private  readonly HttpClient _httpClient = new HttpClient();
        //private static readonly Storages _storages = new Storages();
        //private static readonly IAccessTokenProvider _tokenProvider = new IAccessTokenProvider();
        public UserServices()
        {

        }
      
        public  async Task Signin(string email, string passwd)
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
                Console.WriteLine(response.Content.ReadAsStringAsync().Result + " hoooooooooooooooooooooo");


      
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public  async Task LogIn(string email, string passwd)
        {
            User user = new User()
            {
                Email = email,
                Passwd = passwd,
                Rule= "user"

            };
            var json = JsonSerializer.Serialize(user);
            var data = new StringContent(json, Encoding.UTF8,"application/json");
        
            try
            {
                 var response =  await _httpClient.PostAsync("Https://localhost:10000/Account", data);
                var  res = await response.Content.ReadAsStringAsync();
                IEnumerable<string> lines = res.Split( ':','{', '}');
                var  t = JsonSerializer.Serialize(res);
                User responseUser = await _httpClient.GetFromJsonAsync<User>($"Https://localhost:10000/User/{user.Email}");
                //User responseUser2 = await _httpClient.GetFromJsonAsync<User>($"Https://localhost:10000/User/{user.Email}");
                ////_httpClient.
                //var requestMessage = new HttpRequestMessage()
                //{
                //    Method = new HttpMethod("GET"),
                //    RequestUri = new Uri($"Https://localhost:10000/User/{email}"),
                //    Content = JsonContent.Create(new User
                //    {
                //        Email = email,
                //        Passwd=passwd,

                //    })
                   

                //};
                //requestMessage.Headers.Authorization = new AuthenticationHeaderValue("Bearer", lines.ToList()[2]);
                //var testResponse = await _httpClient.SendAsync(requestMessage);
                //Console.WriteLine(testResponse);
                //var tokenResult = await TokenProvider.RequestAccesToken();
                UserToken token = new UserToken()
                {
                    Token = lines.ToList()[2],
                    Email = responseUser.Email,
                    IsOwner = true,
                    Id = responseUser.IdUser,
                    Rule= responseUser.Rule
                   
                };
                //Console.WriteLine(token.Token);
                
                

               // Storages.SetValueStorage("token", token.Token);

            }
            catch (HttpRequestException ex)
            {
               Console.WriteLine(ex.Message);
            }
        }
    }
}
