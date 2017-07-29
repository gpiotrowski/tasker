using System;
using System.Collections.Generic;
using System.Text;

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
