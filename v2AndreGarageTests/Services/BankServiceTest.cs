using Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace v2AndreGarageTests.Services
{
    public class BankServiceTest
    {
        private static readonly HttpClient _client = new HttpClient();

        public async Task<BankServiceTest> PostBanks (Bank bank)
        {
            try
            {
                var content = new StringContent(JsonConvert.SerializeObject(bank), Encoding.UTF8, "application/json");
                HttpResponseMessage response = await _client.PostAsync("https://localhost:7002;http://localhost:5244", content);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
