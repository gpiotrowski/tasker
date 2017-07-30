using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using EventStore.ClientAPI;
using Newtonsoft.Json;
using Tasker.Common.Core.Events;
using Tasker.Infrastructure.EventStore;

namespace Tasker.Projects.Infractructure.WriteModel.EventStore
{
    public class EventStore : IEventStore
    {
        private readonly IEventStoreConnection _client;

        public EventStore(IEventStoreClientFactory eventStoreClientFactory)
        {
            _client = eventStoreClientFactory.CreateClient();
        }

        public void Save(IEnumerable<IEvent> events, CancellationToken cancellationToken = new CancellationToken())
        {
            var eventedAggregateId = events.Select(x => x.Id).Distinct().Single();
            var eventsToSend = new List<EventData>();

            foreach (var @event in events)
            {
                var eventJson = JsonConvert.SerializeObject(@event, JsonSerializerSharedSettings.Settings);
                var eventToSend = Encoding.ASCII.GetBytes(eventJson);
                var eventData = new EventData(Guid.NewGuid(), @event.GetType().ToString(), true, eventToSend, null);
                eventsToSend.Add(eventData);
            }

            _client.AppendToStreamAsync(eventedAggregateId.ToString(), ExpectedVersion.Any, eventsToSend).Wait();

            Get(eventedAggregateId, 0);
        }

        public IEnumerable<IEvent> Get(Guid aggregateId, int fromVersion, CancellationToken cancellationToken = new CancellationToken())
        {
            var events = new List<IEvent>();

            var lastEvent = _client.ReadEventAsync(aggregateId.ToString(), StreamPosition.End, false).Result;
            if (lastEvent.Status == EventReadStatus.Success)
            {
                var lastEventNumber = lastEvent.Event?.Event.EventNumber;
                int eventsToRead = 0;
                if (lastEventNumber != null)
                {
                    eventsToRead = Convert.ToInt32(lastEventNumber) - fromVersion + 1;
                }
                if (eventsToRead <= 0)
                {
                    return events;
                }

                var eventsSlice = _client
                    .ReadStreamEventsForwardAsync(aggregateId.ToString(), fromVersion, eventsToRead, false).Result;
                var resolvedEvents = eventsSlice.Events;

                foreach (var resolvedEvent in resolvedEvents)
                {
                    var recorderEvent = resolvedEvent.Event;
                    var eventData = recorderEvent.Data;
                    var eventJson = Encoding.ASCII.GetString(eventData);

                    var @event = (IEvent) JsonConvert.DeserializeObject(eventJson, JsonSerializerSharedSettings.Settings);
                    events.Add(@event);
                }
            }

            return events;
        }
    }
}
