using Tasker.Projects.Domain.Commands;
using Tasker.Projects.Domain.Handlers;

namespace Tasker.Projects.Domain.Bus
{
    public class ProjectCommandBus : IProjectCommandBus
    {
        private readonly IProjectCommandHandler _projectCommandHandler;

        public ProjectCommandBus(IProjectCommandHandler projectCommandHandler)
        {
            _projectCommandHandler = projectCommandHandler;
        }

        public void Send(CreateProjectCommand command)
        {
            _projectCommandHandler.Handle(command);
        }
    }
}
