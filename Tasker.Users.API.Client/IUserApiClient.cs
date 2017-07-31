using System;
using System.Threading.Tasks;

namespace Tasker.Users.API.Client
{
    public interface IUserApiClient
    {
        Task<bool> CheckIfUserExist(Guid userId);
    }
}