using System;
using Demo.MessagePatterns.Messages;
using MassTransit;

namespace Demo.MessagingPatterns.SendOnly.Server
{
    class Program
    {
        static void Main(string[] args)
        {
            Bus.Initialize(sbc =>
            {
                sbc.UseRabbitMq();
                sbc.ReceiveFrom("rabbitmq://localhost/Server/Demo.MessagingPatterns.SendOnly.Server1");
                sbc.Subscribe(x => x.Consumer(() => new Consumer()));
            });

            Console.WriteLine("Listening on Server1...");
            Console.ReadLine();
        }
    }

    public class Consumer : Consumes<SampleCommandRequest>.All
    {
        public void Consume(SampleCommandRequest message)
        {
            Console.WriteLine(message.Id);
        }
    }
}
