using Tasker.Users.Application.Requests;
using Tasker.Users.Domain.Commands;

namespace Tasker.Users.Application.Mappers
{
    public class UserCommandMapper : IUserCommandMapper
    {
        public CreateUserCommand MapFromRequst(CreateUserRequest request)
        {
            var createUserCommand = new CreateUserCommand()
            {
                UserName = request.Name
            };

            return createUserCommand;
        }
    }
}
