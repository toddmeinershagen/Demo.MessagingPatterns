using System;
using Demo.MessagePatterns.Messages;
using Magnum.Extensions;
using MassTransit;

namespace Demo.MessagingPatterns.Client
{
    public class AsynchronousRequester : IRequester
    {
        private readonly IServiceBus _bus;

        public AsynchronousRequester(IServiceBus bus)
        {
            _bus = bus;
        }

        public void Send(SampleCommandRequest message)
        {
            var result = _bus.PublishRequestAsync(message, x =>
            {
                x.Handle<SampleCommandReply>(reply =>  Console.WriteLine("Reply Id :: {0}, Net Charges :: {1:c}", reply.Id, reply.NetCharges));
                x.HandleFault(fault => Console.WriteLine(fault.FailedMessage));
                x.SetTimeout(30.Seconds());
            });

            result.Task.Wait();
        }
    }
}