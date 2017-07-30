using Tasker.Users.Domain.Events;
using Tasker.Users.Infrastructure.ReadModel.Models;

namespace Tasker.Users.Domain.Mappers
{
    public class UserReadModelMapper : IUserReadModelMapper
    {
        public UserReadModel Map(UserCreatedEvent userCreatedEvent)
        {
            var userReadModel = new UserReadModel()
            {
                Id = userCreatedEvent.Id,
                Name = userCreatedEvent.Name
            };

            return userReadModel;
        }
    }
}
