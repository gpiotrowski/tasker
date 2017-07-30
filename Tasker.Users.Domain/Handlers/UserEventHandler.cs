using Tasker.Users.Domain.Events;
using Tasker.Users.Domain.Mappers;
using Tasker.Users.Infrastructure.ReadModel.Repositories;

namespace Tasker.Users.Domain.Handlers
{
    public class UserEventHandler : IUserEventHandler
    {
        private readonly IUserReadModelMapper _userReadModelMapper;
        private readonly IUserRepository _userRepository;

        public UserEventHandler(IUserReadModelMapper userReadModelMapper, IUserRepository userRepository)
        {
            _userReadModelMapper = userReadModelMapper;
            _userRepository = userRepository;
        }

        public void Handle(UserCreatedEvent message)
        {
            var userReadModel = _userReadModelMapper.Map(message);
            _userRepository.AddUser(userReadModel);
        }
    }
}
