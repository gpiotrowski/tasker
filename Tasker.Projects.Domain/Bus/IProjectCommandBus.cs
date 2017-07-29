using Tasker.Common.Core.Bus;
using Tasker.Projects.Domain.Commands;

namespace Tasker.Projects.Domain.Bus
{
    public interface IProjectCommandBus : ICommandSender<CreateProjectCommand>
    {
    }
}
