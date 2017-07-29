using Tasker.Infrastructure.Elasticsearch;
using Tasker.Projects.Infractructure.ReadModel.Models;

namespace Tasker.Projects.Infractructure.ReadModel.Repositories
{
    public class ProjectRepository : IProjectRepository
    {
        private readonly IElasticClientFactory _elasticClientFactory;

        public ProjectRepository(IElasticClientFactory elasticClientFactory)
        {
            _elasticClientFactory = elasticClientFactory;
        }

        public void AddProject(ProjectReadModel project)
        {
            var elasticClient = _elasticClientFactory.CreateClient("project");

            var response = elasticClient.Index(project);
        }
    }
}
