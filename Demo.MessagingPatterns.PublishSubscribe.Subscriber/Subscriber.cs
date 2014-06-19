using System;
using Demo.MessagePatterns.Messages;
using MassTransit;

namespace Demo.MessagingPatterns.PublishSubscribe.Subscriber
{
    public class Subscriber : Consumes<SampleEvent>.All
    {
        public void Consume(SampleEvent message)
        {
            Console.WriteLine(string.Format("{0} :: {1}", message.TimeStamp, message.Message));
        }
    }
}