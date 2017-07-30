using System;
using Tasker.Projects.Domain.Events;

namespace Tasker.Users.Domain.Events
{
    public class UserCreatedEvent : EventBase
    {
        public string Name { get; set; }

        public UserCreatedEvent(Guid id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}
