using Demo.MessagingPatterns.Client;
using MassTransit;
using MassTransit.SubscriptionConfigurators;

namespace Demo.MessagingPatterns.Client2
{
    class Program
    {
        static void Main(string[] args)
        {
            Bus.Initialize(sbc =>
            {
                sbc.UseRabbitMq();
                sbc.ReceiveFrom("rabbitmq://localhost/Demo.MessagePatterns.Client2");
                //sbc.Subscribe(x => x.Consumer(() => new ReplyConsumer()));
            });

            var client = new Client.Client("Client2");
            client.Execute();
        }
    }
}
