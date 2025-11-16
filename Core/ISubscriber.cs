namespace PubSubDemo.Core;

public interface ISubscriber
{
    Task HandleAsync(IEvent evt);
}