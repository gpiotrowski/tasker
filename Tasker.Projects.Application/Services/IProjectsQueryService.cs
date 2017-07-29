using System.Collections.Generic;
using Tasker.Projects.Infractructure.ReadModel.Models;

namespace Tasker.Projects.Application.Services
{
    public interface IProjectsQueryService
    {
        List<ProjectReadModel> GetAllProjects();
    }
}