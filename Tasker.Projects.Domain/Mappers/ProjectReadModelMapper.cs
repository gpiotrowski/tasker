using Tasker.Projects.Domain.Events;
using Tasker.Projects.Infractructure.ReadModel.Models;

namespace Tasker.Projects.Domain.Mappers
{
    public class ProjectReadModelMapper : IProjectReadModelMapper
    {
        public ProjectReadModel Map(ProjectCreatedEvent projectCreatedEvent)
        {
            var projectReadModel = new ProjectReadModel()
            {
                Id = projectCreatedEvent.Id,
                Name = projectCreatedEvent.Name
            };

            return projectReadModel;
        }
    }
}
