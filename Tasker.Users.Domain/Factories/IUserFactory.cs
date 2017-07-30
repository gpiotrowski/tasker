using Tasker.Users.Domain.Aggregates;

namespace Tasker.Users.Domain.Factories
{
    public interface IUserFactory
    {
        User CreateUser(string name);
    }
}