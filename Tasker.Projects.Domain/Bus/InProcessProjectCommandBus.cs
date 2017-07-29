using Tasker.Projects.Domain.Commands;
using Tasker.Projects.Domain.Handlers;

namespace Tasker.Projects.Domain.Bus
{
    public class InProcessProjectCommandBus : IProjectCommandBus
    {
        private readonly IProjectCommandHandler _projectCommandHandler;

        public InProcessProjectCommandBus(IProjectCommandHandler projectCommandHandler)
        {
            _projectCommandHandler = projectCommandHandler;
        }

        public void Send(CreateProjectCommand command)
        {
            _projectCommandHandler.Handle(command);
        }
    }
}
