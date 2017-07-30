using Tasker.Users.Domain.Commands;
using Tasker.Users.Domain.Handlers;

namespace Tasker.Users.Domain.Bus
{
    public class InProcessUserCommandBus : IUserCommandBus
    {
        private readonly IUserCommandHandler _userCommandHandler;

        public InProcessUserCommandBus(IUserCommandHandler userCommandHandler)
        {
            _userCommandHandler = userCommandHandler;
        }

        public void Send(CreateUserCommand command)
        {
            _userCommandHandler.Handle(command);
        }
    }
}
