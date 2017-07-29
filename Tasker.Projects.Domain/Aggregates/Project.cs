using System;
using Tasker.Common.Core.Domain;
using Tasker.Projects.Domain.Events;

namespace Tasker.Projects.Domain.Aggregates
{
    //TODO: IApplyEvent<T>
    public class Project : AggregateRoot
    {
        private string _name;

        internal Project(Guid id, string name)
        {
            Id = id;
            ApplyChange(new ProjectCreatedEvent(id, name));
        }

        private void Apply(ProjectCreatedEvent e)
        {
            Version = e.Version;
            _name = e.Name;
        }
    }
}
