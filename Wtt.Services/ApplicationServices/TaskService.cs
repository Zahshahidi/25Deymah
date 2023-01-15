using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using Wtt.DataAccess;
using Wtt.Domain.Entities;
using Wtt.Services.Dto.Task;
using Wtt.Services.Interfaces;
using Wtt.Domain.Entities.Enums;

namespace Wtt.Services.ApplicationServices
{
    internal class TaskService : ITaskService
    {
        private readonly IWttDataAccess _wttDataAccess;

        public TaskService(IWttDataAccess wttDataAccess)
        {
            _wttDataAccess = wttDataAccess;
        }

        public async Task<Domain.Entities.Task> AddTask(TaskCreateDto task)
        {
            var tas = new Domain.Entities.Task
            {

                Title = task.Title,
                Description = task.Description,
                Status = (Domain.Entities.Enums.TaskStatus)task.Status,
                CreateDate = task.CreateDate,
                PerformerId = task.PerformerId,
                EmployeeId = task.EmployeeId
            };

            return await _wttDataAccess.SaveTaskAsync(tas);
        }

        public async Task<TaskReadDto> GetTaskById(int Id)
        {
            var task = await _wttDataAccess.GetTaskAsync(Id);
            return new TaskReadDto
            {
                Title = task.Title,
                Description = task.Description,
                Status = (Domain.Entities.Enums.TaskStatus)task.Status,
                CreateDate = task.CreateDate,
                PerformerId = task.PerformerId,
                EmployeeId = task.EmployeeId
            };
        }

        public async Task<List<TaskReadDto>> GetTasks(int performedId, int EmployeeId, int pageNumber, int pageSize)
        {
            var tasks = await _wttDataAccess.GetTasksAsync(performedId, EmployeeId,pageNumber, pageSize);
            return tasks.Select(t => new TaskReadDto
            {
                Title = t.Title,
                Description = t.Description,
                Status = (Domain.Entities.Enums.TaskStatus)t.Status,
                CreateDate = t.CreateDate,
                PerformerId = t.PerformerId,
                EmployeeId = t.EmployeeId
            }).ToList();
        }

        public async System.Threading.Tasks.Task UpdateTask(TaskUpdateDto task)
        {
            var ta = await _wttDataAccess.GetTaskAsync(task.Id);
            if (ta == null)
            {
                throw new Exception("not found new exception");

            }
            ta.Title = task.Title;
            ta.Description = task.Description;
            ta.Status = (Domain.Entities.Enums.TaskStatus)task.Status;
            ta.CreateDate = task.CreateDate;
            ta.PerformerId = task.PerformerId;
            ta.EmployeeId = task.EmployeeId;

            await _wttDataAccess.UpdateTaskAsync(ta);
        }
        

    }
}
