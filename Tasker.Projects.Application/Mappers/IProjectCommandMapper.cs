using Tasker.Projects.Application.Requests;
using Tasker.Projects.Domain.Commands;

namespace Tasker.Projects.Application.Mappers
{
    public interface IProjectCommandMapper
    {
        CreateProjectCommand MapFromRequest(CreateProjectRequest request);
    }
}