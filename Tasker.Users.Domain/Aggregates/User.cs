using System;
using Tasker.Common.Core.Domain;
using Tasker.Users.Domain.Events;

namespace Tasker.Users.Domain.Aggregates
{
    //TODO: IApplyEvent<T>
    public class User : AggregateRoot
    {
        private string _name;

        internal User(Guid id, string name)
        {
            Id = id;
            ApplyChange(new UserCreatedEvent(id, name));
        }

        private void Apply(UserCreatedEvent e)
        {
            Version = e.Version;
            _name = e.Name;
        }
    }
}
