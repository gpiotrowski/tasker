using System;
using Tasker.Projects.Domain.Events;

namespace Tasker.Projects.Domain.Handlers
{
    public class ProjectEventHandler : IProjectEventHandler
    {
        public void Handle(ProjectCreatedEvent message)
        {
            throw new NotImplementedException();
        }
    }
}
