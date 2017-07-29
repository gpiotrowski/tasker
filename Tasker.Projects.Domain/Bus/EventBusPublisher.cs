using System.Threading;
using Tasker.Common.Core.Events;
using Tasker.Common.Core.Infrastructure;

namespace Tasker.Projects.Domain.Bus
{
    public class EventBusPublisher : IEventPublisher
    {
        private readonly IProjectEventBus _projectEventBus;

        public EventBusPublisher(IProjectEventBus projectEventBus)
        {
            _projectEventBus = projectEventBus;
        }

        public void Publish<T>(T @event, CancellationToken cancellationToken = new CancellationToken()) where T : class, IEvent
        {
            _projectEventBus.AsDynamic().Publish(@event);
        }
    }
}
