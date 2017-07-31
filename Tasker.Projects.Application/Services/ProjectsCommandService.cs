using Tasker.Projects.Application.Exceptions;
using Tasker.Projects.Application.Mappers;
using Tasker.Projects.Application.Requests;
using Tasker.Projects.Application.Validations;
using Tasker.Projects.Domain.Bus;

namespace Tasker.Projects.Application.Services
{
    public class ProjectsCommandService : IProjectsCommandService
    {
        private readonly IProjectCommandMapper _projectCommandMapper;
        private readonly IProjectCommandBus _projectCommandBus;
        private readonly IProjectCommandValidation _projectCommandValidation;

        public ProjectsCommandService(IProjectCommandMapper projectCommandMapper, IProjectCommandBus projectCommandBus, IProjectCommandValidation projectCommandValidation)
        {
            _projectCommandMapper = projectCommandMapper;
            _projectCommandBus = projectCommandBus;
            _projectCommandValidation = projectCommandValidation;
        }

        public void CreateProject(CreateProjectRequest request)
        {
            if (!_projectCommandValidation.IsValid(request))
            {
                throw new UserNotExistException(request.OwnerId);
            };
            var createProjectCommand = _projectCommandMapper.MapFromRequest(request);
            _projectCommandBus.Send(createProjectCommand);
        }
    }
}
