using LaboBadge.Models;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using LaboBadge.Mapper;
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
                Console.WriteLine(response.Content.ReadAsStringAsync().Result + " hoooooooooooooooooooooo");


      
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public static async Task LogIn(string email, string passwd)
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
                Console.WriteLine(data.Headers+" aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaah");
                 var response =  await _httpClient.PostAsync("Https://localhost:10000/Account", data);
                var  res = await response.Content.ReadAsStringAsync();
                //var  res2 = await response.Content.ReadFromJsonAsync<string>();
                Console.WriteLine(res + "fpuuuuuuuuuuuuuuuuuuuuuuuuuutttttttttttttttttttteeeeeeeeeeeee");
                IEnumerable<string> lines = res.Split( ':','{', '}');
                var  t = JsonSerializer.Serialize(res);

                foreach (var kvp in lines)
                {
                    //Console.WriteLine($" key :{kvp.Key} value: {kvp.Value}");
                    Console.WriteLine(kvp +" NIIIIIIIIIIIIIIQQQQQQQQQQQQQQQQQQQQQQQQQQQQQQQQQQQQQQQQ");
                }
                //Console.WriteLine(response.Content.ReadAsStringAsync().Result + " hoooooooooooooooooooooo");
                //string responseBody = await response.Content.ReadAsStringAsync();
                User responseUser = await _httpClient.GetFromJsonAsync<User>($"Https://localhost:10000/User/{user.Email}");
                //Console.WriteLine(responseUser.Content.ReadAsStringAsync().Result + " UUUUUUUUUSssssssssseeeeeeeeerrrrrrrrr");
               //Object js =  responseUser.Content.ReadAsStringAsync().Result;
                //Console.WriteLine(js + " ++++++++++++++++++++++++++++++++++++ ");
               Console.WriteLine(responseUser.IdUser);
                //Console.WriteLine(user1.Email);
                //User user2 = JsonSerializer.Deserialize<User>(js);
                //foreach (var item in js)
                //{
                    //Console.WriteLine(item);
                //}

                //UserToken token = new UserToken()
                //{
                //    Email = user.Email,
                //    Token = response.Content.ReadAsStringAsync().Result,
                //    Id = 0,
                //    IsOwner = true
                //};
                //Console.WriteLine(token.Token);

            }
            catch (HttpRequestException ex)
            {

               Console.WriteLine(ex.Message);
            }
        }
    }
}
