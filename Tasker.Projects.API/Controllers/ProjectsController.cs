using Microsoft.AspNetCore.Mvc;
using Tasker.Projects.Application.Requests;
using Tasker.Projects.Application.Services;

namespace Tasker.Projects.API.Controllers
{
    [Produces("application/json")]
    public class ProjectsController : Controller
    {
        private readonly IProjectsCommandService _projectsCommandService;
        private readonly IProjectsQueryService _projectsQueryService;

        public ProjectsController(IProjectsCommandService projectsCommandService, IProjectsQueryService projectsQueryService)
        {
            _projectsCommandService = projectsCommandService;
            _projectsQueryService = projectsQueryService;
        }

        [HttpPost]
        public IActionResult CreateProject([FromBody]CreateProjectRequest createProjectRequest)
        {
            _projectsCommandService.CreateProject(createProjectRequest);
            return Ok();
        }

        [HttpGet]
        public IActionResult GetProjects()
        {
            var projects = _projectsQueryService.GetAllProjects();
            return Ok(projects);
        }
    }
}