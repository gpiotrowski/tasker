using Tasker.Common.Core.Bus;
using Tasker.Projects.Domain.Events;

namespace Tasker.Projects.Domain.Handlers
{
    public interface IProjectEventHandler : 
        IEventHandler<ProjectCreatedEvent>,
        IEventHandler<ProjectOwnerSettedEvent>
    {
        
    }
}