using PubSubDemo.Core;
using PubSubDemo.Events;

namespace PubSubDemo.Subscribers;

public class EmailWelcomeSubscriber : ISubscriber
{
    public Task HandleAsync(IEvent evt)
    {
        if (evt is UserRegisteredEvent userEvent)
        {
                Console.WriteLine($"[Email] Sending welcome email to {userEvent.Email}");
        }

        return Task.CompletedTask;
        }
}