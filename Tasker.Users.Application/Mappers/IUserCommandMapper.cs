using Tasker.Users.Application.Requests;
using Tasker.Users.Domain.Commands;

namespace Tasker.Users.Application.Mappers
{
    public interface IUserCommandMapper
    {
        CreateUserCommand MapFromRequst(CreateUserRequest request);
    }
}