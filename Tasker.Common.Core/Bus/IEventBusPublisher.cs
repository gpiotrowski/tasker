using Tasker.Common.Core.Events;

namespace Tasker.Common.Core.Bus
{
    public interface IEventBusPublisher<T> where T : IEvent
    {
        void Publish(T @event);
    }
}
