using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using Wtt.DataAccess;
using Wtt.Domain.Entities;
using Wtt.Domain.Entities.Enums;
using Wtt.Services.Dto.Vacation;
using Wtt.Services.Interfaces;

namespace Wtt.Services.ApplicationServices
{
    internal class VacationService : IVacationService
    {
        private readonly IWttDataAccess _wttDataAccess;

        public VacationService(IWttDataAccess wttDataAccess)
        {
            _wttDataAccess = wttDataAccess;
        }
        public async Task<int> AddVacation(VacationCreateDto vacation)
        {
            var vac = new Vacation
            {
                EmployeeId = vacation.EmployeeId,
                Date = vacation.Date,
                Status = vacation.Status
            };
            await _wttDataAccess.SaveVacationAsync(vac);
            return vac.Id;
        }

        public async Task<VacationReadDto> GetVacationById(int Id)
        {
            var vacation = await _wttDataAccess.GetVacationAsync(Id);
            return new VacationReadDto
            {

                EmployeeId = vacation.EmployeeId,
                Date = vacation.Date,
                Status = (int)vacation.Status
               
            };

        }

        public async Task<List<VacationReadDto>> GetVacations(int EmployeeId, DateTime Date, VacationStatus Status, int pageNumber, int pageSize)
        {
            var vacation = await _wttDataAccess.GetVacationsAsync(EmployeeId,Date,Status, pageNumber, pageSize);
            return vacation.Select(v => new VacationReadDto
            {
                EmployeeId = v.EmployeeId,
                Date=v.Date,
                Status= (int)v.Status
            }).ToList();
        }

        public async System.Threading.Tasks.Task UpdateVacation(VacationUpdateDto vacation)
        {
            var vac = await _wttDataAccess.GetVacationAsync(vacation.Id);
            if(vac==null)
            {
                throw new Exception("not found new Exception");
            }
            vac.Id = vacation.Id;
            vac.EmployeeId = vacation.EmployeeId;
            vac.Date = vacation.Date;
            vac.Status = (Domain.Entities.Enums.VacationStatus)vacation.Status;

            await _wttDataAccess.UpdateVacationAsync(vac);
        }
    }
}
