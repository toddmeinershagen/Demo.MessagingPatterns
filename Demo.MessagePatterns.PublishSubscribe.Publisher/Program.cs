using System;
using MassTransit;

namespace Demo.MessagePatterns.PublishSubscribe.Publisher
{
    class Program
    {
        static void Main(string[] args)
        {
            Bus.Initialize(sbc =>
            {
                sbc.UseRabbitMq();
                sbc.ReceiveFrom("rabbitmq://localhost/Demo.MessagePatterns.Publisher");
            });

            var client = new Publisher();
            client.Execute();

            Console.ReadLine();
        }
    }
}
