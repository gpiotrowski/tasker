using Tasker.Projects.Application.Requests;
using Tasker.Projects.Domain.Commands;

namespace Tasker.Projects.Application.Mappers
{
    public class ProjectCommandMapper : IProjectCommandMapper
    {
        public CreateProjectCommand MapFromRequest(CreateProjectRequest request)
        {
            var createProjectCommand = new CreateProjectCommand()
            {
                ProjectName = request.Name,
                OwnerId = request.OwnerId
            };

            return createProjectCommand;
        }
    }
}
