using System.Collections.Generic;
using Tasker.Projects.Infractructure.ReadModel.Models;
using Tasker.Projects.Infractructure.ReadModel.Repositories;

namespace Tasker.Projects.Application.Services
{
    public class ProjectsQueryService : IProjectsQueryService
    {
        private readonly IProjectRepository _projectRepository;

        public ProjectsQueryService(IProjectRepository projectRepository)
        {
            _projectRepository = projectRepository;
        }

        public List<ProjectReadModel> GetAllProjects()
        {
            var projects = _projectRepository.GetAllProjects();

            return projects;
        }
    }
}
