using System.Threading;

namespace Tasker.Common.Core.Events
{
    public interface IEventPublisher
    {
        void Publish<T>(T @event, CancellationToken cancellationToken = default(CancellationToken)) where T : class, IEvent;
    }
}
