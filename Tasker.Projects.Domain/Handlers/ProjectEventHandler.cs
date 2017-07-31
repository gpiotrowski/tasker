using Tasker.Projects.Domain.Events;
using Tasker.Projects.Domain.Mappers;
using Tasker.Projects.Infractructure.ReadModel.Repositories;

namespace Tasker.Projects.Domain.Handlers
{
    public class ProjectEventHandler : IProjectEventHandler
    {
        private readonly IProjectReadModelMapper _projectReadModelMapper;
        private readonly IProjectRepository _projectRepository;

        public ProjectEventHandler(IProjectReadModelMapper projectReadModelMapper, IProjectRepository projectRepository)
        {
            _projectReadModelMapper = projectReadModelMapper;
            _projectRepository = projectRepository;
        }

        public void Handle(ProjectCreatedEvent message)
        {
            var projectReadModel = _projectReadModelMapper.Map(message);
            _projectRepository.AddProject(projectReadModel);
        }

        public void Handle(ProjectOwnerSettedEvent message)
        {
            _projectRepository.SetProjectOwner(message.Id, message.OwnerId);
        }
    }
}
