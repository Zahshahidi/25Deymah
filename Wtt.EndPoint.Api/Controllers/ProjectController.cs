using Microsoft.AspNetCore.Mvc;
using Wtt.Services.Dto.Mission;
using Wtt.Services.Dto.Project;
using Wtt.Services.Interfaces;

namespace Wtt.EndPoint.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProjectController
    {
        private readonly ILogger<ProjectController> _logger;
        private readonly IProjectService _projectService;

        public ProjectController(ILogger<ProjectController> logger, IProjectService projectService)
        {
            _logger = logger;
            _projectService = projectService;
        }
        [HttpPost]
        public async Task<int> AddProject(ProjectCreateDto project)
        {
            return await _projectService.AddProject(project);
        }

        [HttpDelete]
        public async System.Threading.Tasks.Task DeleteProject(int Id)
        {
            await _projectService.DeleteProject(Id);
        }

        [HttpGet]
        public async Task<ProjectReadDto> GetProjectById(int Id)
        {
            return await _projectService.GetProjectById(Id);
        }

        [HttpGet("all")]
        public async Task<List<ProjectReadDto>> GetProjects(string Name, int pageNumber, int pageSize)
        {
            return await _projectService.GetProjects(Name, pageNumber, pageSize);
        }

        [HttpPut]
        public async System.Threading.Tasks.Task UpdateProject(ProjectUpdateDto project)
        {
            await _projectService.UpdateProject(project);
        }
    }
}
