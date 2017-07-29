using System;
using Tasker.Common.Core.Commands;

namespace Tasker.Projects.Domain.Commands
{
    public class CreateProjectCommand : ICommand
    {
        public int ExpectedVersion { get; set;  }
        public string ProjectName { get; set; }
    }
}
