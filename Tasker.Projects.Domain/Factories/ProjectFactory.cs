using System;
using Tasker.Projects.Domain.Aggregates;

namespace Tasker.Projects.Domain.Factories
{
    public class ProjectFactory : IProjectFactory
    {
        public Project CreateProject(string name)
        {
            var id = Guid.NewGuid();
            var project = new Project(id, name);

            return project;
        }
    }
}
