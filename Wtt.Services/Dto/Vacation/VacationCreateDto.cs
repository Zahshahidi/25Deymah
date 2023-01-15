

using Wtt.Domain.Entities.Enums;

namespace Wtt.Services.Dto.Vacation
{
    public class VacationCreateDto

    { 
        public int EmployeeId { get; set; }

        public DateTime Date { get; set; }

        public VacationStatus Status { get; set; }

    }
}
