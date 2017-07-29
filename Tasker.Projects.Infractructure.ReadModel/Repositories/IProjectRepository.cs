using Tasker.Projects.Infractructure.ReadModel.Models;

namespace Tasker.Projects.Infractructure.ReadModel.Repositories
{
    public interface IProjectRepository
    {
        void AddProject(ProjectReadModel project);
    }
}