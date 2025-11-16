using PubSubDemo.Core;

namespace PubSubDemo.Events;

public class UserRegisteredEvent : IEvent
{
    public string UserId { get; }
    public string Email { get; }
    public DateTime RegisteredAt { get; }

    public UserRegisteredEvent(string userId, string email)
    {
        UserId = userId;
        Email = email;
        RegisteredAt = DateTime.UtcNow;
    }
}