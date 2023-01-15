using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wtt.Services.Dto.Task;

namespace Wtt.Services.Interfaces
{
    public interface ITaskService
    {
        //Task<int> AddTask(TaskCreateDto task);
        Task UpdateTask(TaskUpdateDto task);
        Task<TaskReadDto> GetTaskById(int Id);
        Task<List<TaskReadDto>> GetTasks(int performedId, int EmployeeId, int pageNumber, int pageSize);
        Task<Domain.Entities.Task> AddTask(TaskCreateDto task);
    }
}
