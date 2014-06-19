using System;
using MassTransit;

namespace Demo.MessagingPatterns.Server
{
    class Program
    {
        static void Main(string[] args)
        {
            Bus.Initialize(sbc =>
            {
                sbc.UseRabbitMq();
                sbc.ReceiveFrom("rabbitmq://localhost/Demo.MessagePatterns.Server");
                sbc.Subscribe(subs => subs.Consumer(() => new Consumer()));
            });

            Console.WriteLine("Server listening for requests...");
            Console.ReadLine();
        }
    }
}
