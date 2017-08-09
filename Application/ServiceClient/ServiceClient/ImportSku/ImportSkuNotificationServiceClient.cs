using System;
using System.Text;
using EcommercerCatalog.Application.ServiceClient.Message.ImportSku;
using Newtonsoft.Json;
using RabbitMQ.Client;

namespace EcommercerCatalog.Application.ServiceClient.ServiceClient.ImportSku
{
    public class ImportSkuNotificationServiceClient
    {
        public void NotitifyImport(ImportSkuNotificationMessageRequest request) 
        {
             var factory = new ConnectionFactory() { HostName = "localhost" };
                using(var connection = factory.CreateConnection())
                using(var channel = connection.CreateModel())
                {
                    channel.QueueDeclare(queue: "importSku",
                                        durable: false,
                                        exclusive: false,
                                        autoDelete: false,
                                        arguments: null);

                    string message = JsonConvert.SerializeObject(request);

                    var body = Encoding.UTF8.GetBytes(message);

                    channel.BasicPublish(exchange: "",
                                        routingKey: "importSku",
                                        basicProperties: null,
                                        body: body);

                }
        }
    }
}