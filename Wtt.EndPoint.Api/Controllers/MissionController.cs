using Microsoft.AspNetCore.Mvc;
using Wtt.Services.Dto.Mission;
using Wtt.Services.Interfaces;

namespace Wtt.EndPoint.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MissionController
    {       

        private readonly ILogger<MissionController> _logger;
        private readonly IMissionService _missionService;

        public MissionController(ILogger<MissionController> logger, IMissionService missionService)
        {
            _logger = logger;
            _missionService = missionService;
        }
        [HttpPost]
        public async Task<int> AddMission(MissionCreateDto mission)
        {
            return await _missionService.AddMission(mission);
        }

        [HttpDelete]
        public async System.Threading.Tasks.Task DeleteMission(int Id)
        {
            await _missionService.DeleteMission(Id);
        }

        [HttpGet]
        public async Task<MissionReadDto> GetMissionById(int Id)
        {
            return await _missionService.GetMissionById(Id);
        }

        [HttpGet("all")]
        public async Task<List<MissionReadDto>> GetMissions(DateTime Date, int EmployeeId, int ProjectId, int pageNumer, int pageSize)
        {
            return await _missionService.GetMissions(Date, EmployeeId, ProjectId, pageNumer, pageSize);
        }

        [HttpPut]
        public async System.Threading.Tasks.Task UpdateMission(MissionUpdateDto mission)
        {
            await _missionService.UpdateMission(mission);
        }
    }
}
