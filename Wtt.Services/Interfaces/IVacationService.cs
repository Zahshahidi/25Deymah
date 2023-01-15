using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wtt.Domain.Entities.Enums;
using Wtt.Services.Dto.Vacation;

namespace Wtt.Services.Interfaces
{
    public interface IVacationService
    {
        Task<int> AddVacation(VacationCreateDto vacation);
        Task UpdateVacation(VacationUpdateDto vacation);
        Task<VacationReadDto> GetVacationById(int Id);
        Task<List<VacationReadDto>> GetVacations(int EmployeeId, DateTime Date, VacationStatus Status, int pageNumber, int pageSize);
    }
}
