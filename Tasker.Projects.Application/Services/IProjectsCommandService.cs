using Tasker.Projects.Application.Requests;

namespace Tasker.Projects.Application.Services
{
    public interface IProjectsCommandService
    {
        void CreateProject(CreateProjectRequest request);
    }
}