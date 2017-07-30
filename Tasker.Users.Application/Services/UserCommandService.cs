using Tasker.Users.Application.Mappers;
using Tasker.Users.Application.Requests;
using Tasker.Users.Domain.Bus;

namespace Tasker.Users.Application.Services
{
    public class UserCommandService : IUserCommandService
    {
        private readonly IUserCommandMapper _userCommandMapper;
        private readonly IUserCommandBus _userCommandBus;

        public UserCommandService(IUserCommandMapper userCommandMapper, IUserCommandBus userCommandBus)
        {
            _userCommandMapper = userCommandMapper;
            _userCommandBus = userCommandBus;
        }

        public void CreateUser(CreateUserRequest request)
        {
            var createUserCommand = _userCommandMapper.MapFromRequst(request);
            _userCommandBus.Send(createUserCommand);
        }
    }
}
