using AndreGarageFinancing.Repository;
using Models;
using Models.DTO;
using Newtonsoft.Json;

namespace AndreGarageFinancing.Services
{
    public class FinancingService
    {
        private readonly HttpClient _client = new HttpClient();
        private readonly FinancingRepository _repository;
        public FinancingService(FinancingRepository repository)
        {
            _repository = repository;
        }

        public async Task<Financing> CreateFinancing(FinancingDTO dto)
        {
            try
            {
                HttpResponseMessage response = await _client.GetAsync($"https://localhost:7208/api/Sales/{dto.SaleId}");
                HttpResponseMessage responsebank = await _client.GetAsync($"https://localhost:7002/api/Banks/{dto.BankCnpj}");
                var sale = JsonConvert.DeserializeObject<Sale>(await response.Content.ReadAsStringAsync());
                var bank = JsonConvert.DeserializeObject<Bank>(await responsebank.Content.ReadAsStringAsync());
                if (sale == null || bank == null)
                {
                    return null;
                }
                else
                {
                    Financing financing = new Financing
                    {
                        Id = dto.Id,
                        Sale = sale,
                        Bank = bank,
                        FinancingDate = dto.FinancingDate
                    };
                    var rows = _repository.Insert(dto);
                    if (rows > 0)
                    {
                        return financing;
                    }
                    else
                    {
                        return null;
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        public async Task<List<Financing>> GetAll()
        {
            var listfinancing = await _repository.GetAll();
            var financings = new List<Financing>();
            try
            {
                foreach (var dto in listfinancing)
                {
                    HttpResponseMessage response = await _client.GetAsync($"https://localhost:7208/api/Sales/{dto.SaleId}");
                    HttpResponseMessage responsebank = await _client.GetAsync($"https://localhost:7002/api/Banks/{dto.BankCnpj}");
                    var sale = JsonConvert.DeserializeObject<Sale>(await response.Content.ReadAsStringAsync());
                    var bank = JsonConvert.DeserializeObject<Bank>(await responsebank.Content.ReadAsStringAsync());
                    if (sale == null || bank == null)
                    {
                        return null;
                    }
                    else
                    {
                        Financing financing = new Financing
                        {
                            Id = dto.Id,
                            Sale = sale,
                            Bank = bank,
                            FinancingDate = dto.FinancingDate
                        };
                        financings.Add(financing);
                    }
                }
                return financings;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<Financing> Get(int id)
        {
            var dto = await _repository.Get(id);
            HttpResponseMessage response = await _client.GetAsync($"https://localhost:7208/api/Sales/{dto.SaleId}");
            HttpResponseMessage responsebank = await _client.GetAsync($"https://localhost:7002/api/Banks/{dto.BankCnpj}");
            var sale = JsonConvert.DeserializeObject<Sale>(await response.Content.ReadAsStringAsync());
            var bank = JsonConvert.DeserializeObject<Bank>(await responsebank.Content.ReadAsStringAsync());
            if (sale == null || bank == null)
            {
                return null;
            }
            else
            {
                Financing financing = new Financing
                {
                    Id = dto.Id,
                    Sale = sale,
                    Bank = bank,
                    FinancingDate = dto.FinancingDate
                };
                return financing;
            }
        }
    }
}

