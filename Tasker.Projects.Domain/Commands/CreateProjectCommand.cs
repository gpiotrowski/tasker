using Tasker.Common.Core.Commands;

namespace Tasker.Projects.Domain.Commands
{
    public class CreateProjectCommand : ICommand
    {
        public int ExpectedVersion { get; }
        public string ProjectName { get; set; }
    }
}
