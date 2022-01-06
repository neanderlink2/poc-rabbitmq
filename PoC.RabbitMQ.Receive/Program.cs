using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;

Console.WriteLine("Hello, World!");

var factory = new ConnectionFactory() { HostName = "localhost" };
using (var connection = factory.CreateConnection())
using (var channel = connection.CreateModel())
{
    channel.ExchangeDeclare(exchange: "logs", ExchangeType.Fanout);
    var queueName = channel.QueueDeclare().QueueName;
    channel.QueueBind(queueName, exchange: "logs", routingKey: "");

    var consumer = new EventingBasicConsumer(channel);
    consumer.Received += (model, args) =>
    {
        var body = args.Body.ToArray();
        var message = Encoding.UTF8.GetString(body);
        Console.WriteLine("[x] Received {0}", message);
    };

    channel.BasicConsume(queue: queueName, true, consumer);

    Console.WriteLine("Press [enter] to exit.");
    Console.ReadLine();
}