using System;
using System.Collections.Generic;
using Tasker.Projects.Infractructure.ReadModel.Models;

namespace Tasker.Projects.Infractructure.ReadModel.Repositories
{
    public interface IProjectRepository
    {
        void AddProject(ProjectReadModel project);
        List<ProjectReadModel> GetAllProjects();
        void SetProjectOwner(Guid projectId, Guid ownerId);
    }
}