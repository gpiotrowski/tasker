using Tasker.Common.Core.Bus;
using Tasker.Users.Domain.Commands;

namespace Tasker.Users.Domain.Bus
{
    public interface IUserCommandBus : ICommandSender<CreateUserCommand>
    {
    }
}