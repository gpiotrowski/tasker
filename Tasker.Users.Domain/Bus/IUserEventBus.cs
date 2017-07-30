using Tasker.Common.Core.Bus;
using Tasker.Users.Domain.Events;

namespace Tasker.Users.Domain.Bus
{
    public interface IUserEventBus : IEventBus, IEventBusPublisher<UserCreatedEvent>
    {
        
    }
}