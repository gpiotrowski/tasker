using Tasker.Users.Application.Requests;

namespace Tasker.Users.Application.Services
{
    public interface IUserCommandService
    {
        void CreateUser(CreateUserRequest request);
    }
}