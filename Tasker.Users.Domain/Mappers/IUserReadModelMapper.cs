using Tasker.Users.Domain.Events;
using Tasker.Users.Infrastructure.ReadModel.Models;

namespace Tasker.Users.Domain.Mappers
{
    public interface IUserReadModelMapper
    {
        UserReadModel Map(UserCreatedEvent userCreatedEvent);
    }
}