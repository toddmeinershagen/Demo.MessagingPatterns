using System;
using System.Threading.Tasks;
using Demo.MessagePatterns.Messages;
using MassTransit;

namespace Demo.MessagingPatterns.Server
{
    public class Consumer : Consumes<SampleCommandRequest>.Context
    {
        private readonly Random _generator = new Random();

        public void Consume(IConsumeContext<SampleCommandRequest> context)
        {
            Console.WriteLine("Received request {0}", context.Message.Id);
            context.Respond(GetResponseMessage(context.Message));
            //Action action = () => SendResponse(context);
            //Parallel.Invoke(action);
        }

        private SampleCommandReply GetResponseMessage(SampleCommandRequest request)
        {
            return new SampleCommandReply {Id = request.Id, NetCharges = 1 + _generator.NextDouble()};
        }

        private void SendResponse(IConsumeContext<SampleCommandRequest> context)
        {
            Bus.Instance.GetEndpoint(context.ResponseAddress).Send(GetResponseMessage(context.Message), ctx =>
            {
                ctx.SetSourceAddress(Bus.Instance.Endpoint.Address.Uri);
                ctx.SetRequestId(context.RequestId);
            });
        }
    }
}