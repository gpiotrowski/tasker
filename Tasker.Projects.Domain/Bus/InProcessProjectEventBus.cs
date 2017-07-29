using Tasker.Projects.Domain.Events;
using Tasker.Projects.Domain.Handlers;

namespace Tasker.Projects.Domain.Bus
{
    public class InProcessProjectEventBus : IProjectEventBus
    {
        private readonly IProjectEventHandler _projectEventHandler;

        public InProcessProjectEventBus(IProjectEventHandler projectEventHandler)
        {
            _projectEventHandler = projectEventHandler;
        }

        public void Publish(ProjectCreatedEvent @event)
        {
            _projectEventHandler.Handle(@event);
        }
    }
}
