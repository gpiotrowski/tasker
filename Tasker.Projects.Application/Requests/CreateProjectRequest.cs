using System;

namespace Tasker.Projects.Application.Requests
{
    public class CreateProjectRequest
    {
        public string Name { get; set; }
        public Guid OwnerId { get; set; }
    }
}
