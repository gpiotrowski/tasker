using Tasker.Common.Core.Domain;
using Tasker.Projects.Domain.Commands;
using Tasker.Projects.Domain.Factories;

namespace Tasker.Projects.Domain.Handlers
{
    public class ProjectCommandHandler : IProjectCommandHandler
    {
        private readonly ISession _session;
        private readonly IProjectFactory _projectFactory;

        public ProjectCommandHandler(ISession session, IProjectFactory projectFactory)
        {
            _session = session;
            _projectFactory = projectFactory;
        }

        public void Handle(CreateProjectCommand message)
        {
            var project = _projectFactory.CreateProject(message.ProjectName, message.OwnerId);
            _session.Add(project);
            _session.Commit();
        }
    }
}
