using Microsoft.AspNetCore.Mvc;
using Models;
using MongoDB.Bson;
using Newtonsoft.Json;
using RabbitMQ.Client;
using System.Text;

namespace AndreGarageBank.Services
{
    public class BankRabbit
    {
        
        private const string QUEUE_NAME = "bank_queue";


        public Bank PostBank(ConnectionFactory _factory,[FromBody] Bank bank)
        {
            using (var connection = _factory.CreateConnection())
            {
                using (var channel = connection.CreateModel())
                {
                    channel.QueueDeclare(queue: QUEUE_NAME,
                                         durable: false,
                                         exclusive: false,
                                         autoDelete: false,
                                         arguments: null);

                    var stringBank = JsonConvert.SerializeObject(bank);
                    var bytesBank = Encoding.UTF8.GetBytes(stringBank);

                    channel.BasicPublish(exchange: "",
                                         routingKey: QUEUE_NAME,
                                         basicProperties: null,
                                         body: bytesBank);
                }
            } return bank;
        }
    }
}
