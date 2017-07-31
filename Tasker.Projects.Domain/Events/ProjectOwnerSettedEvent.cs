using System;

namespace Tasker.Projects.Domain.Events
{
    public class ProjectOwnerSettedEvent : EventBase
    {
        public Guid OwnerId { get; set; }

        public ProjectOwnerSettedEvent(Guid ownerId)
        {
            OwnerId = ownerId;
        }
    }
}
