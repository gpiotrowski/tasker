using Tasker.Projects.Domain.Aggregates;

namespace Tasker.Projects.Domain.Factories
{
    public class ProjectFactory
    {
        public Project CreateProject(string name)
        {
            var project = new Project(name);

            return project;
        }
    }
}
