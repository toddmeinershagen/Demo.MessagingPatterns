using System;
using MassTransit;

namespace Demo.MessagingPatterns.PublishSubscribe.Subscriber
{
    class Program
    {
        static void Main(string[] args)
        {
            Bus.Initialize(sbc =>
            {
                sbc.UseRabbitMq();
                sbc.ReceiveFrom("rabbitmq://localhost/Demo.MessagePatterns.Subscriber");
                sbc.Subscribe(x => x.Consumer(() => new Subscriber()));
            });

            Console.WriteLine("Subscriber1 :: Ready to receive messages...");
            Console.ReadLine();
        }
    }
}
