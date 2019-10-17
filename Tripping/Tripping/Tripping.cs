using System;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
namespace Tripping
{

    public class Tripping
    {
        private static HttpClient HttpClient
            = new HttpClient() { BaseAddress = new Uri("https://services.odata.org/TripPinRESTierService/(S(qlwcpzuphcqgeqh1dzdvkyip))/") };

        public static void Init(string key)
        {

            HttpClient = new HttpClient() { BaseAddress = new Uri("https://services.odata.org/TripPinRESTierService/"+key+"People") };
        }
        public static async void Post(string body)
        {
            var content = new StringContent(JsonSerializer.Serialize(body), Encoding.UTF8, "application/json");
            var response = await HttpClient.PostAsync("People", content);

        }
        public static async Task GetAsync()
        {
            var pokemonResponse = await HttpClient.GetAsync("People");
            pokemonResponse.EnsureSuccessStatusCode();
            var responseBody = await pokemonResponse.Content.ReadAsStringAsync();
            var response = responseBody.Split("},{\"UserName");
            for(var i= 1;i < response.Length;i++){
                
                response[i] = "\"UserName"+ response[i];
                Console.WriteLine(response[i]);
                Console.WriteLine();
            }
            
        }
        public static async Task<string> GetSingleAsync(string UserName)
        {
            var pokemonResponse = await HttpClient.GetAsync("People('"+UserName+"')");
            var responseBody = await pokemonResponse.Content.ReadAsStringAsync();
            //Console.WriteLine(responseBody);
            
            return responseBody;
        }
    }
}
