using Tasker.Projects.Domain.Events;
using Tasker.Projects.Infractructure.ReadModel.Models;

namespace Tasker.Projects.Domain.Mappers
{
    public interface IProjectReadModelMapper
    {
        ProjectReadModel Map(ProjectCreatedEvent projectCreatedEvent);
    }
}