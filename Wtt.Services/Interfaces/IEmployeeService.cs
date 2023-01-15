using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wtt.Domain.Entities.Enums;
using Wtt.Services.Dto;

namespace Wtt.Services.Interfaces
{
    public interface IEmployeeService
    {
        Task<int> AddEmployee(EmployeeCreateDto employee);
        Task UpdateEmployee(EmployeeUpdateDto employee);
        Task DeleteEmployee(int employeeId);
        Task<EmployeeReadDto> GetEmployeeById(int employeeId);
        Task<List<EmployeeReadDto>> GetEmployees(string name, Gender gender, int pageNumer, int pageSize);
    }
}
