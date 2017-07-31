using Microsoft.AspNetCore.Mvc;
using Tasker.Users.Application.Requests;
using Tasker.Users.Application.Services;

namespace Tasker.Users.API.Controllers
{
    [Produces("application/json")]
    public class UsersController : Controller
    {
        private readonly IUserCommandService _userCommandService;
        private readonly IUserQueryService _userQueryService;

        public UsersController(IUserCommandService userCommandService, IUserQueryService userQueryService)
        {
            _userCommandService = userCommandService;
            _userQueryService = userQueryService;
        }

        [HttpPost]
        public IActionResult CreateUser([FromBody]CreateUserRequest createUserRequest)
        {
            _userCommandService.CreateUser(createUserRequest);
            return Ok();
        }

        public IActionResult CheckIfUserExist(CheckIfUserExistRequest checkIfUserExistRequest)
        {
            var isUserExist = _userQueryService.CheckIfUserExist(checkIfUserExistRequest);

            if (isUserExist)
            {
                return Ok();
            }
            return NotFound();
        }
    }
}
