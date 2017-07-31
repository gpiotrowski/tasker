using Tasker.Common.Core.Bus;
using Tasker.Projects.Domain.Events;

namespace Tasker.Projects.Domain.Bus
{
    public interface IProjectEventBus : 
        IEventBus,
        IEventBusPublisher<ProjectCreatedEvent>,
        IEventBusPublisher<ProjectOwnerSettedEvent>
    {
        
    }
}