using Tasker.Common.Core.Bus;
using Tasker.Users.Domain.Events;

namespace Tasker.Users.Domain.Handlers
{
    public interface IUserEventHandler : IEventHandler<UserCreatedEvent>
    {

    }
}