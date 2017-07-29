using Nest;

namespace Tasker.Infrastructure.Elasticsearch
{
    public interface IElasticClientFactory
    {
        ElasticClient CreateClient();
        ElasticClient CreateClient(string defaultIndex);
    }
}