using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using Tasker.Common.Core.Events;

namespace Tasker.Projects.Infractructure.WriteModel.EventStore
{
    public class InMemoryEventStore : IEventStore
    {
        private readonly Dictionary<Guid, List<IEvent>> _inMemoryStore = new Dictionary<Guid, List<IEvent>>();

        public void Save(IEnumerable<IEvent> events, CancellationToken cancellationToken = new CancellationToken())
        {
            var eventedAggregateId = events.Select(x => x.Id).Distinct().Single();

            _inMemoryStore.TryGetValue(eventedAggregateId, out List<IEvent> list);
            if (list == null)
            {
                list = new List<IEvent>();
                _inMemoryStore.Add(eventedAggregateId, list);
            }
            list.AddRange(events);
        }

        public IEnumerable<IEvent> Get(Guid aggregateId, int fromVersion, CancellationToken cancellationToken = new CancellationToken())
        {
            _inMemoryStore.TryGetValue(aggregateId, out List<IEvent> events);
            return events != null
                ? events.Where(x => x.Version > fromVersion)
                : new List<IEvent>();
        }
    }
}
