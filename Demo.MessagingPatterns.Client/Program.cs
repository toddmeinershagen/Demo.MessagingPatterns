using MassTransit;

namespace Demo.MessagingPatterns.Client
{
    class Program
    {
        static void Main(string[] args)
        {
            Bus.Initialize(sbc =>
            {
                sbc.UseRabbitMq();
                sbc.ReceiveFrom("rabbitmq://localhost/Demo.MessagePatterns.Client");
                //sbc.Subscribe(x => x.Consumer(() => new ReplyConsumer()));
            });

            var client = new Client("Client1");
            client.Execute();
        }
    }
}
