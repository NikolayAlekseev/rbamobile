using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Rbauto.Models;

namespace Rbauto.Services
{
    public class CrmApiService
    {
        //private const string URL = "http://mssqlvm.sim:81/api/account/";
        private const string URL = "http://alekseevn.ru:82/api/account/";

        public static async Task<AccountEntity> GetAccountByInnAsync(string inn)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(URL);

            // Add an Accept header for JSON format.
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));

            // List data response.
            var response = client.GetAsync($"{URL}{inn}").Result; // Blocking call!
            if (response.IsSuccessStatusCode)
            {
                // Parse the response body. Blocking!
                var resultString = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<AccountEntity>(resultString);
            }
            throw new Exception($"{response.StatusCode} {response.ReasonPhrase}");
        }

        public async static Task<AccountEntity> GetAccountByInnFake(string inn)
        {
            return null;
        }
    }
}