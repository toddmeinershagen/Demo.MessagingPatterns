using System;
using Demo.MessagePatterns.Messages;
using MassTransit;

namespace Demo.MessagePatterns.PublishSubscribe.Publisher
{
    public class Publisher
    {
        public void Execute()
        {
            while (UserWantsToSendMessage())
            {
                var messageId = Guid.NewGuid();
                Bus.Instance.Publish(new SampleEvent
                {
                    Id = messageId,
                    Message = string.Format("This is a message for message id:  {0}", messageId),
                    TimeStamp = DateTimeOffset.Now
                });

                Console.Write("Successfully published message for id:  {0}", messageId);
            }
        }

        private bool UserWantsToSendMessage()
        {
            Console.Write("Hit ENTER to send a message.  Type 'q' to quit.");
            return Console.ReadLine() != "q";
        }
    }
}