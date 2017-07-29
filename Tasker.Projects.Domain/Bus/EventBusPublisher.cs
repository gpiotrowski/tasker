using System.Threading;
using Tasker.Common.Core.Events;

namespace Tasker.Projects.Domain.Bus
{
    public class EventBusPublisher : IEventPublisher
    {
        public void Publish<T>(T @event, CancellationToken cancellationToken = new CancellationToken()) where T : class, IEvent
        {
            
        }
    }
}
