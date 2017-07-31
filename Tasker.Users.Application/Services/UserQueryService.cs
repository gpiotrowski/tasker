using Tasker.Users.Application.Requests;
using Tasker.Users.Infrastructure.ReadModel.Repositories;

namespace Tasker.Users.Application.Services
{
    public class UserQueryService : IUserQueryService
    {
        private readonly IUserRepository _userRepository;

        public UserQueryService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public bool CheckIfUserExist(CheckIfUserExistRequest checkIfUserExistRequest)
        {
            var isUserExist = _userRepository.CheckIfUserExist(checkIfUserExistRequest.Id);

            return isUserExist;
        }
    }
}
