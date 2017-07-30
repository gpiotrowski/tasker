using System;

namespace Tasker.Projects.Domain.Events
{
    public class ProjectCreatedEvent : EventBase
    {
        public string Name { get; }

        public ProjectCreatedEvent(Guid id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}
