using System;
using MassTransit;

namespace Demo.MessagePatterns.PublishSubscribe.Subscriber2
{
    class Program
    {
        static void Main(string[] args)
        {
            Bus.Initialize(sbc =>
            {
                sbc.UseRabbitMq();
                sbc.ReceiveFrom("rabbitmq://localhost/Demo.MessagePatterns.Subscriber2");
                sbc.Subscribe(x => x.Consumer(() => new Subscriber()));
            });

            Console.WriteLine("Subscriber2 :: Ready to receive messages...");
            Console.ReadLine();
        }
    }
}
