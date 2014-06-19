using System;
using Demo.MessagePatterns.Messages;
using MassTransit;

namespace Demo.MessagingPatterns.Client
{
    public class Client
    {
        private readonly string _name;

        public Client(string name)
        {
            _name = name;
        }

        public void Execute()
        {   
            while(UserWantsToSendMessage())
            {
                var request = new SampleCommandRequest {Id = Guid.NewGuid()};
                Console.WriteLine("{0} :: Request sent with id {1}", _name, request.Id);

                IRequester requester;
                requester = new SynchronousRequester(Bus.Instance);
                //requester = new AsynchronousRequester(Bus.Instance);
                //requester = new TotallyAsynchronousRequester(Bus.Instance);
                requester.Send(request);

            }

            Console.ReadLine();
        }

        private bool UserWantsToSendMessage()
        {
            Console.Write("Hit ENTER to send a message.  Type 'q' to quit.");
            return Console.ReadLine() != "q";
        }
    }

    public interface IRequester
    {
        void Send(SampleCommandRequest request);
    }

    public class TotallyAsynchronousRequester : IRequester
    {
        private readonly IServiceBus _bus;

        public TotallyAsynchronousRequester(IServiceBus bus)
        {
            _bus = bus;
        }

        public void Send(SampleCommandRequest request)
        {
            _bus.Publish(request, x =>
            {
                x.SetResponseAddress(_bus.Endpoint.Address.Uri);
                x.SetRequestId(Guid.NewGuid().ToString());
            });
        }
    }
}