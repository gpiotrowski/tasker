using System;
using Tasker.Users.Domain.Aggregates;

namespace Tasker.Users.Domain.Factories
{
    public class UserFactory : IUserFactory
    {
        public User CreateUser(string name)
        {
            var id = Guid.NewGuid();
            var user = new User(id, name);

            return user;
        }
    }
}
