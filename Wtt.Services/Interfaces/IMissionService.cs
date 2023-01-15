using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wtt.Services.Dto.Mission;

namespace Wtt.Services.Interfaces
{
    public interface IMissionService
    {
        Task<int> AddMission(MissionCreateDto mission);
        Task UpdateMission(MissionUpdateDto mission);
        Task DeleteMission(int Id);
        Task<MissionReadDto> GetMissionById(int Id);
        Task<List<MissionReadDto>> GetMissions(DateTime Date, int EmployeeId, int ProjectId, int pageNumer, int pageSize);

    }
}
