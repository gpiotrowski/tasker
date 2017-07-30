using EventStore.ClientAPI;

namespace Tasker.Infrastructure.EventStore
{
    public interface IEventStoreClientFactory
    {
        IEventStoreConnection CreateClient();
    }
}