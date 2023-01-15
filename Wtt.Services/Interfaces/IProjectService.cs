using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wtt.Services.Dto.Project;

namespace Wtt.Services.Interfaces
{
    public interface IProjectService
    {
        Task<int> AddProject(ProjectCreateDto project);
        Task UpdateProject(ProjectUpdateDto project);
        Task DeleteProject(int Id);
        Task<ProjectReadDto> GetProjectById(int Id);
        Task<List<ProjectReadDto>> GetProjects(string Name, int pageNumber, int pageSize);


    }
}
