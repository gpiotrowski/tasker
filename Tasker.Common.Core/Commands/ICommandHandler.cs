using Tasker.Common.Core.Messages;

namespace Tasker.Common.Core.Commands
{
    public interface ICommandHandler<T> : IHandler<T> where T : ICommand
    {
    }
}
