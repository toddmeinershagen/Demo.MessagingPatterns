using System;
using Demo.MessagePatterns.Messages;
using MassTransit;

namespace Demo.MessagingPatterns.Client
{
    public class ReplyConsumer : Consumes<SampleCommandReply>.Context
    {
        public void Consume(IConsumeContext<SampleCommandReply> reply)
        {
            Console.WriteLine("Reply Id :: {0}, Net Charges :: {1:c}", reply.Message.Id, reply.Message.NetCharges);
            Console.WriteLine();
        }
    }
}