using PubSubDemo.Core;
using PubSubDemo.Events;

namespace PubSubDemo.Subscribers;

public class AnalyticsSubscriber : ISubscriber
{
    public Task HandleAsync(IEvent evt)
    {
        if (evt is UserRegisteredEvent userEvent)
        {
            Console.WriteLine($"[Analytics] Logging registration for {userEvent.Email}");
        }

        return Task.CompletedTask;
    }
}