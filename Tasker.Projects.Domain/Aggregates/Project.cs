using System;
using Tasker.Common.Core.Domain;
using Tasker.Projects.Domain.Events;

namespace Tasker.Projects.Domain.Aggregates
{
    //TODO: IApplyEvent<T>
    public class Project : AggregateRoot
    {
        private string _name;
        private Guid _ownerId;

        internal Project(Guid id, string name)
        {
            Id = id;
            ApplyChange(new ProjectCreatedEvent(id, name));
        }

        public void SetOwner(Guid ownerId)
        {
            var projectOwnerSettedEvent = new ProjectOwnerSettedEvent(ownerId);
            ApplyChange(projectOwnerSettedEvent);
        }

        private void Apply(ProjectCreatedEvent e)
        {
            Version = e.Version;
            _name = e.Name;
        }

        private void Apply(ProjectOwnerSettedEvent e)
        {
            Version = e.Version;
            _ownerId = e.OwnerId;
        }
    }
}
