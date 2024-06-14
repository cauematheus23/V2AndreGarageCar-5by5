using Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AndreGarageConsumerBank.Services
{
    public class BankServiceConsumer
    {
        private static readonly HttpClient _httpClient = new HttpClient();

        public async Task<Bank> PostBank(Bank bank)
        {
            try
            {
                var content = new StringContent(JsonConvert.SerializeObject(bank), Encoding.UTF8, "application/json");
                HttpResponseMessage respose = await BankServiceConsumer._httpClient.PostAsync("https://localhost:7163/api/SendBanks", content);
                respose.EnsureSuccessStatusCode();
                string bankReturn = await respose.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<Bank>(bankReturn);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
