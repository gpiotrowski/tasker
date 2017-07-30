using Tasker.Users.Infrastructure.ReadModel.Models;

namespace Tasker.Users.Infrastructure.ReadModel.Repositories
{
    public interface IUserRepository
    {
        void AddUser(UserReadModel user);
    }
}