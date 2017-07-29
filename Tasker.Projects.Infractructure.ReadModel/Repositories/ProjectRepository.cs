using System.Collections.Generic;
using System.Linq;
using Nest;
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
            var client = GetElasticClient();

            var response = client.Index(project);
        }

        public List<ProjectReadModel> GetAllProjects()
        {
            var client = GetElasticClient();

            var searchResponse = client.Search<ProjectReadModel>();
            return searchResponse.Documents.ToList();
        }

        private IElasticClient GetElasticClient()
        {
            var elasticClient = _elasticClientFactory.CreateClient("project");

            return elasticClient;
        }
    }
}
