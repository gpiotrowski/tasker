using Tasker.Users.Application.Requests;

namespace Tasker.Users.Application.Services
{
    public interface IUserQueryService
    {
        bool CheckIfUserExist(CheckIfUserExistRequest checkIfUserExistRequest);
    }
}