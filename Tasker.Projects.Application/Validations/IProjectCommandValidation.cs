using Tasker.Projects.Application.Requests;

namespace Tasker.Projects.Application.Validations
{
    public interface IProjectCommandValidation
    {
        bool IsValid(CreateProjectRequest request);
    }
}