using System;
using Demo.MessagePatterns.Messages;
using MassTransit;

namespace Demo.MessagingPatterns.SendOnly.Client
{
    class Program
    {
        static void Main(string[] args)
        {
            Bus.Initialize(sbc =>
            {
                sbc.UseRabbitMq();
                sbc.ReceiveFrom("rabbitmq://localhost/Server/Demo.MessagingPatterns.SendOnly.Client");
                //sbc.Subscribe(x => x.Consumer(() => new ReplyConsumer()));
            });

            var client = new Client();
            client.Execute();
        }
    }

    public class Client
    {
        public void Execute()
        {
            string serverName;

            while (UserWantsToSendMessage(out serverName))
            {
                var request = new SampleCommandRequest {Id = Guid.NewGuid()};
                Bus.Instance.GetEndpoint(new Uri(string.Format("rabbitmq://localhost/Server/Demo.MessagingPatterns.SendOnly.{0}", serverName)))
                    .Send(request);
            }

            Console.ReadLine();
        }

        private bool UserWantsToSendMessage(out string serverName)
        {
            Console.Write("Type number of server (1 or 2) and hit ENTER to send a message.  Type 'q' to quit.");
            var input = Console.ReadLine();
            serverName = input == "1" ? "Server1" : "Server2";
            
            return input != "q";
        }
    }
}
