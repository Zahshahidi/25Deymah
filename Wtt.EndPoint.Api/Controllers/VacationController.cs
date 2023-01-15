using Microsoft.AspNetCore.Mvc;
using Wtt.Domain.Entities.Enums;
using Wtt.Services.Dto.Mission;
using Wtt.Services.Dto.Vacation;
using Wtt.Services.Interfaces;

namespace Wtt.EndPoint.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class VacationController
    {
        private readonly ILogger<VacationController> _logger;
        private readonly IVacationService _vacationService;

        public VacationController(ILogger<VacationController> logger, IVacationService vacationService)
        {
            _logger = logger;
            _vacationService = vacationService;
        }
        [HttpPost]

        public async Task<int> AddVacation(VacationCreateDto vacation)
        {
            return await _vacationService.AddVacation(vacation);
        }

        [HttpDelete]
        //public async System.Threading.Tasks.Task DeleteVacation(int Id)
        //{
            //await _vacationService.DeleteVacation(Id);
        //}

        [HttpGet]
        public async Task<VacationReadDto> GetVacationById(int Id)
        {
            return await _vacationService.GetVacationById(Id);
        }

        [HttpGet("all")]
        public async Task<List<VacationReadDto>> GetVacations(int EmployeeId, DateTime Date, VacationStatus Status, int pageNumber, int pageSize)
        {
            return await _vacationService.GetVacations(EmployeeId, Date, Status, pageNumber, pageSize);
        }

        [HttpPut]
        public async System.Threading.Tasks.Task UpdateVacation(VacationUpdateDto vacation)
        {
            await _vacationService.UpdateVacation(vacation);
        }
    }
}
