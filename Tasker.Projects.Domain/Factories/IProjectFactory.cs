using Tasker.Projects.Domain.Aggregates;

namespace Tasker.Projects.Domain.Factories
{
    public interface IProjectFactory
    {
        Project CreateProject(string name);
    }
}