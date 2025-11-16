using PubSubDemo.Core;
using PubSubDemo.Events;

namespace PubSubDemo.Subscribers;

public class SmsWelcomeSubscriber : ISubscriber
{
    
    public Task HandleAsync(IEvent evt)
    {
        if (evt is UserRegisteredEvent userEvent)
        {
            Console.WriteLine($"[SMS] Sending welcome SMS to {userEvent.Email}");
        }

        return Task.CompletedTask;
    }
}