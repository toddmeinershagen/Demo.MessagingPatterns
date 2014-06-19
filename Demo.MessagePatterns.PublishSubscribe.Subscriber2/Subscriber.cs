using System;
using Demo.MessagePatterns.Messages;
using MassTransit;

namespace Demo.MessagePatterns.PublishSubscribe.Subscriber2
{
    public class Subscriber : Consumes<SampleEvent>.All
    {
        public void Consume(SampleEvent message)
        {
            Console.WriteLine(string.Format("{0} :: {1}", message.TimeStamp, message.Message));
        }
    }
}