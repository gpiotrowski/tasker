using Microsoft.AspNetCore.Mvc;
using Tasker.Users.Application.Requests;
using Tasker.Users.Application.Services;

namespace Tasker.Users.API.Controllers
{
    [Produces("application/json")]
    public class UsersController : Controller
    {
        private readonly IUserCommandService _userCommandService;

        public UsersController(IUserCommandService userCommandService)
        {
            _userCommandService = userCommandService;
        }

        [HttpPost]
        public IActionResult CreateUser([FromBody]CreateUserRequest createUserRequest)
        {
            _userCommandService.CreateUser(createUserRequest);
            return Ok();
        }
    }
}
