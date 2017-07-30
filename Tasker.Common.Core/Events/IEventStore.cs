using System;
using System.Collections.Generic;
using System.Threading;

namespace Tasker.Common.Core.Events
{
    public interface IEventStore
    {
        void Save(IEnumerable<IEvent> events, CancellationToken cancellationToken = default(CancellationToken));
        IEnumerable<IEvent> Get(Guid aggregateId, int fromVersion, CancellationToken cancellationToken = default(CancellationToken));
    }
}
