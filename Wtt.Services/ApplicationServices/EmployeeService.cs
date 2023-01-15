using Wtt.DataAccess;
using Wtt.Domain.Entities;
using Wtt.Domain.Entities.Enums;
using Wtt.Services.Dto;
using Wtt.Services.Interfaces;

namespace Wtt.Services.ApplicationServices
{
    internal class EmployeeService : IEmployeeService
    {
        private readonly IWttDataAccess _wttDataAccess;

        public EmployeeService(IWttDataAccess wttDataAccess)
        {
            _wttDataAccess = wttDataAccess;
        }

        public async Task<int> AddEmployee(EmployeeCreateDto employee)
        {
            var user = new User
            {
                Username = employee.Username,
                Password = employee.Password
            };

            await _wttDataAccess.SaveUserAsync(user);

            var emp = new Employee
            {
                Username = employee.Username,
                Fullname = employee.Fullname,
                Age = employee.Age,
                EnrollmentDate = DateTime.Now,
                Gender = employee.Gender,
                Grade = employee.Grade
            };
            await _wttDataAccess.SaveEmployeeAsync(emp);

            return emp.Id;
        }

        public async System.Threading.Tasks.Task DeleteEmployee(int employeeId)
        {
            var employee = await _wttDataAccess.GetEmployeeAsync(employeeId);
            if (employee == null)
            {
                throw new Exception("not found exception");
            }
            await _wttDataAccess.DeleteEmployee(employee);

        }

        public async Task<EmployeeReadDto> GetEmployeeById(int employeeId)
        {
            var employee = await _wttDataAccess.GetEmployeeAsync(employeeId);
            return new EmployeeReadDto
            {
                Age = employee.Age,
                Fullname = employee.Fullname,
                Gender = employee.Gender,
                Grade = employee.Grade,
                Id = employee.Id
            };

        }

        public async Task<List<EmployeeReadDto>> GetEmployees(string name, Gender gender, int pageNumber, int pageSize)
        {

            var employees = await _wttDataAccess.GetEmployeesAsync(name,gender, pageNumber, pageSize);
            return employees.Select(e => new EmployeeReadDto
            {
                Age = e.Age,
                Fullname = e.Fullname,
                Gender = e.Gender,
                Grade = e.Grade,
                Id = e.Id
            }
            ).ToList();
        }

        public async System.Threading.Tasks.Task UpdateEmployee(EmployeeUpdateDto employee)
        {

            var emp = await _wttDataAccess.GetEmployeeAsync(employee.Id);
            if (employee == null)
            {
                throw new Exception("not found exception");
            }
            emp.Age = employee.Age;
            emp.Fullname = employee.Fullname;
            emp.Gender = employee.Gender;
            emp.Grade = employee.Grade;

            await _wttDataAccess.UpdateEmployeeAsync(emp);



        }
    }
}
