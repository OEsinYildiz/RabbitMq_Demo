using System.Text;
using RabbitMQ.Client;

// Baglanti Acma

ConnectionFactory factory = new();
factory.Uri = new("amqps://tgvytqvu:o4JZc8Hv42aJlr-1aJb32N4JQPE5HAWz@goose.rmq2.cloudamqp.com/tgvytqvu");

// Baglantiyi Aktiflestirme ve Kanal Acma
using IConnection connection = factory.CreateConnection();
using IModel channel = connection.CreateModel();

// Queue Olusturma
channel.QueueDeclare(queue: "example-queue", exclusive: false);

// Queue`ya Mesaj Gonderme
// RabbitMq kuyruga atacagi mesajlari byte turunde kabul etmektedir. 
/*byte[] message = Encoding.UTF8.GetBytes("hello, Bro");

channel.BasicPublish("", "example-queue", body:message);*/

for (int i = 0; i < 1000; i++)
{
    byte[] message = Encoding.UTF8.GetBytes($"hello, Bro {i}");

    channel.BasicPublish("", "example-queue", body:message);
}

Console.Read();