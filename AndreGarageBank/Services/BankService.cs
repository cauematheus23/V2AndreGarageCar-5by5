using AndreGarageBank.Utils;
using Models;
using MongoDB.Driver;

namespace AndreGarageBank.Services
{
    public class BankService
    {
        private readonly IMongoCollection<Bank> _bank;

        public BankService(IDataBaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _bank = database.GetCollection<Bank>(settings.BankCollectionName);
        }
        public List<Bank> GetAll() => _bank.Find(bank => true).ToList();
        
        public Bank Get(string cnpj) => _bank.Find<Bank>(bank => bank.CNPJ == cnpj).FirstOrDefault();

        public Bank Create(Bank bank)
        {
         
            return bank;
        }
        public Bank Update(Bank bank) 
        {
            _bank.ReplaceOne(b => b.CNPJ == bank.CNPJ, bank);
            return bank;
        }
        public void Remove(Bank bank) => _bank.DeleteOne(b => b.CNPJ == bank.CNPJ);
    }
}
