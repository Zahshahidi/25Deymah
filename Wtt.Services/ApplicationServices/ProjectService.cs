using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Wtt.DataAccess;
using Wtt.Domain.Entities;
using Wtt.Services.Dto.Mission;
using Wtt.Services.Dto.Project;
using Wtt.Services.Interfaces;

namespace Wtt.Services.ApplicationServices
{
    internal class ProjectService : IProjectService
    {
        private readonly IWttDataAccess _wttDataAccess;

        public ProjectService(IWttDataAccess wttDataAccess)
        {
            _wttDataAccess = wttDataAccess;


        }

        public async  Task<int> AddProject(ProjectCreateDto project)
        {
            var pro = new Project
            {
               
                Name = project.Name
            };
            await _wttDataAccess.SaveProjectAsync(pro);
            return pro.Id;
        }

        public async System.Threading.Tasks.Task  DeleteProject(int Id)
        {

            var project = await _wttDataAccess.GetProjectAsync(Id);
            if (project == null)
            {
                throw new Exception("not found exception");
            }
            await _wttDataAccess.DeleteProjectAsync(project);
        }

        public async Task<ProjectReadDto> GetProjectById(int Id)
        {
            var project = await _wttDataAccess.GetProjectAsync(Id);
            return new ProjectReadDto
            {
                Id = project.Id,
                Name = project.Name
            };
        }
        public async Task<List<ProjectReadDto>> GetProjects(string Name, int pageNumber, int pageSize)
        {

            var projects = await _wttDataAccess.GetProjectsAsync(Name, pageNumber, pageSize);
            return projects.Select(p => new ProjectReadDto
            {
                Id = p.Id,
                Name = p.Name
            }).ToList();
        }


        public async System.Threading.Tasks.Task  UpdateProject(ProjectUpdateDto project)
        {
            var proj = await _wttDataAccess.GetProjectAsync(project.Id);
            if (proj == null)
            {
                throw new Exception("not found exception");
            }
            proj.Id = project.Id;
            proj.Name = project.Name;

            await _wttDataAccess.UpdateProjectAsync(proj);
        }
    }
}
