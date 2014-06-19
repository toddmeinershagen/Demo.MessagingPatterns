using System;

namespace Demo.MessagePatterns.Messages
{
    public class SampleEvent
    {
        public Guid Id { get; set; }
        public string Message { get; set; }
        public DateTimeOffset TimeStamp { get; set; }
    }
}
