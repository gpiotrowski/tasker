using System;
using Nest;

namespace Tasker.Infrastructure.Elasticsearch
{
    public class ElasticClientFactory : IElasticClientFactory
    {
        public ElasticClient CreateClient()
        {

            var serverUrl = GetNodeUri();
            var settings = new ConnectionSettings(serverUrl);
            var elasticClient = new ElasticClient(settings);

            CheckConnection(elasticClient);

            return elasticClient;
        }

        public ElasticClient CreateClient(string defaultIndex)
        {
            var serverUrl = GetNodeUri();
            var settings = new ConnectionSettings(serverUrl).DefaultIndex(defaultIndex);
            var elasticClient = new ElasticClient(settings);

            CheckConnection(elasticClient);

            return elasticClient;
        }

        private Uri GetNodeUri()
        {
            //TODO: Move to configuration file
            var serverUri = new Uri("http://localhost:32777");

            return serverUri;
        }

        private void CheckConnection(IElasticClient client)
        {
            //TODO: Validate connection
            var connectionHealthReponse = client.CatHealth();
        }
    }
}
