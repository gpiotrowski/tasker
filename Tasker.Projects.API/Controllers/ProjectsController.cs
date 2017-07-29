using System;
using Microsoft.AspNetCore.Mvc;
using Tasker.Projects.Application.Requests;
using Tasker.Projects.Application.Services;

namespace Tasker.Projects.API.Controllers
{
    [Produces("application/json")]
    [Route("api/Projects")]
    public class ProjectsController : Controller
    {
        private readonly IProjectsCommandService _projectsCommandService;

        public ProjectsController(IProjectsCommandService projectsCommandService)
        {
            _projectsCommandService = projectsCommandService;
        }

        [HttpPost]
        public IActionResult CreateProject([FromBody]CreateProjectRequest createProjectRequest)
        {
            _projectsCommandService.CreateProject(createProjectRequest);
            return Ok();
        }

        [HttpGet]
        public IActionResult GetUserProjects(Guid userId)
        {
            return Ok();
        }
    }
}