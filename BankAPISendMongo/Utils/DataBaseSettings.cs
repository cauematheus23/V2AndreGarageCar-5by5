namespace AndreGarageSendBank.Utils
{
    public class DataBaseSettings : IDataBaseSettings
    {
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
        public string BankCollectionName { get; set; }
    }
}
