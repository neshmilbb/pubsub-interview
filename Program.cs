using PubSubDemo.Events;
using PubSubDemo.Infrastructure;
using PubSubDemo.Subscribers;

namespace PubSubDemo
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var eventBus = new EventBus();

            // Register subscribers
            eventBus.RegisterSubscriber<UserRegisteredEvent>(new EmailWelcomeSubscriber());
            eventBus.RegisterSubscriber<UserRegisteredEvent>(new SmsWelcomeSubscriber());
            eventBus.RegisterSubscriber<UserRegisteredEvent>(new AnalyticsSubscriber());

            // Publish event
            var userRegistered = new UserRegisteredEvent("123", "user@example.com");
            await eventBus.PublishAsync(userRegistered);
        }
    }
}