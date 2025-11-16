using PubSubDemo.Core;

namespace PubSubDemo.Events;

public class UserRegisteredEvent(string userId, string email) : IEvent
{
    public string UserId { get; } = userId;
    public string Email { get; } = email;
    public DateTime RegisteredAt { get; } = DateTime.UtcNow;
}