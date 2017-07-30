using Tasker.Users.Domain.Events;
using Tasker.Users.Domain.Handlers;

namespace Tasker.Users.Domain.Bus
{
    public class InProcessUserEventBus : IUserEventBus
    {
        private readonly IUserEventHandler _userEventHandler;

        public InProcessUserEventBus(IUserEventHandler userEventHandler)
        {
            _userEventHandler = userEventHandler;
        }

        public void Publish(UserCreatedEvent @event)
        {
            _userEventHandler.Handle(@event);
        }
    }
}
