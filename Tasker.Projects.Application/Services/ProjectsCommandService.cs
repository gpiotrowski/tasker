using Tasker.Projects.Application.Mappers;
using Tasker.Projects.Application.Requests;
using Tasker.Projects.Domain.Bus;

namespace Tasker.Projects.Application.Services
{
    public class ProjectsCommandService : IProjectsCommandService
    {
        private readonly IProjectCommandMapper _projectCommandMapper;
        private readonly IProjectCommandBus _projectCommandBus;

        public ProjectsCommandService(IProjectCommandMapper projectCommandMapper, IProjectCommandBus projectCommandBus)
        {
            _projectCommandMapper = projectCommandMapper;
            _projectCommandBus = projectCommandBus;
        }

        public void CreateProject(CreateProjectRequest request)
        {
            var createProjectCommand = _projectCommandMapper.MapFromRequest(request);
            _projectCommandBus.Send(createProjectCommand);
        }
    }
}
