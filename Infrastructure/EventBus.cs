using PubSubDemo.Core;

namespace PubSubDemo.Infrastructure;

public class EventBus : IPublisher
{
    private readonly Dictionary<Type, List<ISubscriber>> _subscribers =
        new Dictionary<Type, List<ISubscriber>>();

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

        if (!_subscribers.ContainsKey(eventType))
            return;

        var subscribers = _subscribers[eventType];

        var tasks = subscribers.Select(s => s.HandleAsync(evt));
        await Task.WhenAll(tasks);
    }
}