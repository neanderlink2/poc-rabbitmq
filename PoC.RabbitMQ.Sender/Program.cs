using RabbitMQ.Client;
using System.Text;

Console.WriteLine("Hello, World!");

var factory = new ConnectionFactory() { HostName = "localhost" };
using (var connection = factory.CreateConnection())
using (var channel = connection.CreateModel())
{
    channel.ExchangeDeclare("logs", ExchangeType.Fanout);
    var message = "Hello World";
    var body = Encoding.UTF8.GetBytes(message);

    channel.BasicPublish(exchange: "logs",
        routingKey: "",
        basicProperties: null,
        body: body);

    Console.WriteLine("[x] Sent {0}", message);
}

Console.WriteLine(" Press [enter] to exit.");
Console.ReadLine();