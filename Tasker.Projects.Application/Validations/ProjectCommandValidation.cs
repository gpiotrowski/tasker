using System;
using System.Threading.Tasks;
using Tasker.Projects.Application.Requests;
using Tasker.Users.API.Client;

namespace Tasker.Projects.Application.Validations
{
    public class ProjectCommandValidation : IProjectCommandValidation
    {
        private readonly IUserApiClient _userApiClient;

        public ProjectCommandValidation(IUserApiClient userApiClient)
        {
            _userApiClient = userApiClient;
        }

        public bool IsValid(CreateProjectRequest request)
        {
            return CheckIfUserExist(request.OwnerId).Result;
        }

        private async Task<bool> CheckIfUserExist(Guid userId)
        {
            var isUserExist = await _userApiClient.CheckIfUserExist(userId);
            return isUserExist;
        }
    }
}
