using Tasker.Common.Core.Events;
using Tasker.Common.Core.Messages;

namespace Tasker.Common.Core.Bus
{
    public interface IEventHandler<T> : IHandler<T> where T : IEvent
    {
    }
}
