using System;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
namespace TrippingLibrary
{

    public class Class1
    {
        private static HttpClient HttpClient
            = new HttpClient() { BaseAddress = new Uri("https://services.odata.org/TripPinRESTierService/(S(qlwcpzuphcqgeqh1dzdvkyip))//People") };

        public static void Init(string key)
        {
            
            HttpClient = new HttpClient() { BaseAddress = new Uri("https://services.odata.org/TripPinRESTierService/(S(qlwcpzuphcqgeqh1dzdvkyip))//People") };
        }
        public static void Post(string body){
            var content = new StringContent(JsonSerializer.Serialize(body), Encoding.UTF8, "application/json");
            var pokemonResponse = await HttpClient.PostAsync("pokemon", content)

        }
        public static void Get()
        {
            https://services.odata.org/TripPinRESTierService/People('russellwhyte')
        }

    }
}
