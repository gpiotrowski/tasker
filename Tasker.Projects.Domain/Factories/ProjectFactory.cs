using System;
using Tasker.Projects.Domain.Aggregates;

namespace Tasker.Projects.Domain.Factories
{
    public class ProjectFactory : IProjectFactory
    {
        public Project CreateProject(string name, Guid ownerId)
        {
            var id = Guid.NewGuid();
            var project = new Project(id, name);

            project.SetOwner(ownerId);

            return project;
        }
    }
}
