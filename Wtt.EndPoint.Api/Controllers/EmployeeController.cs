using Microsoft.AspNetCore.Mvc;
using Wtt.Domain.Entities.Enums;
using Wtt.Services.Dto;
using Wtt.Services.Interfaces;

namespace Wtt.EndPoint.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EmployeeController
    {
        private readonly ILogger<EmployeeController> _logger;
        private readonly IEmployeeService _employeeService;

        public EmployeeController(ILogger<EmployeeController> logger, IEmployeeService employeeService)
        {
            _logger = logger;
            _employeeService = employeeService;
        }

        [HttpPost]
        public async Task<int> AddEmployee(EmployeeCreateDto employee)
        {
            return await _employeeService.AddEmployee(employee);
        }


        [HttpDelete]
        public async System.Threading.Tasks.Task DeleteEmployee(int employeeId)
        {
            await _employeeService.DeleteEmployee(employeeId);

        }


        [HttpGet]
        public async Task<EmployeeReadDto> GetEmployeeById(int employeeId)
        {
            return await _employeeService.GetEmployeeById(employeeId);
        }


        [HttpGet("all")]
        public async Task<List<EmployeeReadDto>> GetEmployees(string name, Gender gender, int pageNumer, int pageSize)
        {

            return await _employeeService.GetEmployees(name,gender, pageNumer, pageSize);
        }


        [HttpPut]
        public async System.Threading.Tasks.Task UpdateEmployee(EmployeeUpdateDto employee)
        {
            await _employeeService.UpdateEmployee(employee);
        }
    }
}
