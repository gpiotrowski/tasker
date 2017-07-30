using Tasker.Common.Core.Commands;

namespace Tasker.Users.Domain.Commands
{
    public class CreateUserCommand : ICommand
    {
        public int ExpectedVersion { get; set; }
        public string UserName { get; set; }
    }
}
