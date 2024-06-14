using AndreGarageConsumerBank.Services;
using Models;
using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;

const string QUEUE_NAME = "bank_queue";
var factory = new ConnectionFactory() { HostName = "localhost" };
using (var connection = factory.CreateConnection())
{
    using (var channel = connection.CreateModel())
    {
        channel.QueueDeclare(queue: QUEUE_NAME,
                      durable: false,
                      exclusive: false,
                      autoDelete: false,
                      arguments: null);

        while (true)
        {
            var consumer = new EventingBasicConsumer(channel);
            consumer.Received += (model, ea) =>
            {
                var body = ea.Body.ToArray();
                var returnBank = Encoding.UTF8.GetString(body);
                var bank = JsonConvert.DeserializeObject<Bank>(returnBank);
                Bank msg = new BankServiceConsumer().PostBank(bank).Result;
                Bank SQL = new BankServiceConsumer().PostBankSQL(bank).Result;
                Console.WriteLine("Mongo Bank: " + msg.Name);
                Console.WriteLine("SQL Bank: " + SQL.Name);
            };

            channel.BasicConsume(queue: QUEUE_NAME,
                                 autoAck: true,
                                 consumer: consumer);

            Thread.Sleep(2000);
        }
    }
}