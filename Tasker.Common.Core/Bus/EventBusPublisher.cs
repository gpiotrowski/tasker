using System.Threading;
using Tasker.Common.Core.Events;
using Tasker.Common.Core.Infrastructure;

namespace Tasker.Common.Core.Bus
{
    public class EventBusPublisher : IEventPublisher
    {
        private readonly IEventBus _eventBus;

        public EventBusPublisher(IEventBus eventBus)
        {
            _eventBus = eventBus;
        }

        public void Publish<T>(T @event, CancellationToken cancellationToken = new CancellationToken()) where T : class, IEvent
        {
            _eventBus.AsDynamic().Publish(@event);
        }
    }
}
