using Tasker.Common.Core.Messages;

namespace Tasker.Common.Core.Commands
{
    public interface ICommand : IMessage
    {
        int ExpectedVersion { get; }
    }
}
