
// Baglanti Olusturma
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;

ConnectionFactory factory = new();
factory.Uri = new("amqps://tgvytqvu:o4JZc8Hv42aJlr-1aJb32N4JQPE5HAWz@goose.rmq2.cloudamqp.com/tgvytqvu");

// Baglanti Aktiflestirme ve kanal Acma
using IConnection connection = factory.CreateConnection();
using IModel channel = connection.CreateModel();

// Queue Olusturma
channel.QueueDeclare("example-queue", exclusive: false);

// Oueue`dan Mesaj Okuma
var consumer = new EventingBasicConsumer(channel);
channel.BasicConsume(queue: "example-queue", true, consumer); // Burada mesaj geldigi zaman consume et dedik

consumer.Received += (sender, args) =>
{
    Console.WriteLine(Encoding.UTF8.GetString(args.Body.Span));
};

Console.Read();

