using PubSubDemo.Core;

namespace PubSubDemo.Infrastructure;

public class EventBus : IPublisher
{
    private readonly Dictionary<Type, List<ISubscriber>> _subscribers = new();

    public void RegisterSubscriber<TEvent>(ISubscriber subscriber) where TEvent : IEvent
    {
        var eventType = typeof(TEvent);

        if (!_subscribers.ContainsKey(eventType))
            _subscribers[eventType] = new List<ISubscriber>();

        _subscribers[eventType].Add(subscriber);
    }

    public async Task PublishAsync(IEvent evt)
    {
        var eventType = evt.GetType();

        if (!_subscribers.TryGetValue(eventType, out var subscribers))
            return;

        var tasks = subscribers.Select(s => s.HandleAsync(evt));
        await Task.WhenAll(tasks);
    }
}