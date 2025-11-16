namespace PubSubDemo.Core;

public interface IPublisher
{
    Task PublishAsync(IEvent evt);

}