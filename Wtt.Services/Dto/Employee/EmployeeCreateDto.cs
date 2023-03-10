

using Wtt.Domain.Entities.Enums;

namespace Wtt.Services.Dto
{
    public class EmployeeCreateDto
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string Fullname { get; set; }
        public Grade Grade { get; set; }
        public int Age { get; set; }
        public Gender Gender { get; set; }
    }
}
