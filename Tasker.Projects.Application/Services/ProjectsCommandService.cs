using Tasker.Projects.Application.Mappers;
using Tasker.Projects.Application.Requests;
using Tasker.Projects.Application.Services;

namespace Tasker.Projects.Application
{
    public class ProjectsCommandService : IProjectsCommandService
    {
        private readonly IProjectCommandMapper _projectCommandMapper;

        public ProjectsCommandService(IProjectCommandMapper projectCommandMapper)
        {
            _projectCommandMapper = projectCommandMapper;
        }

        public void CreateProject(CreateProjectRequest request)
        {
            var projectCreateCommand = _projectCommandMapper.MapFromRequest(request);
        }
    }
}
