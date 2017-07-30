using System.Net;
using EventStore.ClientAPI;

namespace Tasker.Infrastructure.EventStore
{
    public class EventStoreClientFactory : IEventStoreClientFactory
    {
        public IEventStoreConnection CreateClient()
        {
            var connection = EventStoreConnection.Create(GetEndpoint());
            connection.ConnectAsync().Wait();

            return connection;
        }

        private IPEndPoint GetEndpoint()
        {
            //TODO: Move to configuration file
            var address = "127.0.0.1";
            var port = 32774;

            IPAddress.TryParse(address, out IPAddress ipAddress);
            var endpoint = new IPEndPoint(ipAddress, port);

            return endpoint;
        }
    }
}
