using AndreGarageSendBank.Utils;
using Models;
using MongoDB.Driver;

namespace AndreGarageSendBank.Services
{
    public class SendBankService
    {
        private readonly IMongoCollection<Bank> _bank;

        public SendBankService(IDataBaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _bank = database.GetCollection<Bank>(settings.BankCollectionName);
        }

        public Bank Create(Bank bank)
        {
            _bank.InsertOne(bank);
            return bank;
        }
    }
}
