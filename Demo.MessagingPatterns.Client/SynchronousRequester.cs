using System;
using Demo.MessagePatterns.Messages;
using Magnum.Extensions;
using MassTransit;

namespace Demo.MessagingPatterns.Client
{
    public class SynchronousRequester : IRequester
    {
        private readonly IServiceBus _bus;

        public SynchronousRequester(IServiceBus bus)
        {
            _bus = bus;
        }

        public void Send(SampleCommandRequest request)
        {
            _bus.PublishRequest(request, x =>
            {
                x.Handle<SampleCommandReply>(reply =>
                {
                    Console.WriteLine("Reply Id :: {0}, Net Charges :: {1:c}", reply.Id, reply.NetCharges);
                    Console.WriteLine();
                });
                x.SetTimeout(30.Seconds());
            });
        }
    }
}