using Microsoft.AspNetCore.Mvc;
using Wtt.Services.Dto.Mission;
using Wtt.Services.Dto.Task;
using Wtt.Services.Interfaces;

namespace Wtt.EndPoint.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TaskController
    {
        private readonly ILogger<TaskController> _logger;
        private readonly ITaskService _taskService;

        public TaskController(ILogger<TaskController> logger, ITaskService taskService)
        {
            _logger = logger;
            _taskService = taskService;
        }
        [HttpPost]
        public async Task<int> AddTask(TaskCreateDto task)
        {
            var createdTask =  await _taskService.AddTask(task);
            return createdTask.Id;
        }

        [HttpDelete]
        public async System.Threading.Tasks.Task DeleteTask(int Id)
        {
            //await _taskService.DeleteTask(Id);
        }

        [HttpGet]
        public async Task<TaskReadDto> GetTaskById(int Id)
        {
            return await _taskService.GetTaskById(Id);
        }

        [HttpGet("all")]
        public async Task<List<TaskReadDto>> GeTasks(int performedId, int EmployeeId, int pageNumber, int pageSize)
        {
            return await _taskService.GetTasks(performedId, EmployeeId, pageNumber, pageSize);
        }

        [HttpPut]
        public async System.Threading.Tasks.Task UpdateTask(TaskUpdateDto task)
        {
            await _taskService.UpdateTask(task);
        }
    }
}
