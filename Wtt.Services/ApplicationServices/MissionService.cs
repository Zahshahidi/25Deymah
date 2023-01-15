using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wtt.DataAccess;
using Wtt.Domain.Entities;
using Wtt.Services.Dto.Mission;
using Wtt.Services.Interfaces;

namespace Wtt.Services.ApplicationServices
{
    internal class MissionService : IMissionService
    {
        private readonly IWttDataAccess _wttDataAccess;

        public MissionService(IWttDataAccess wttDataAccess)
        {
            _wttDataAccess = wttDataAccess;
        }
        public async Task<int> AddMission(MissionCreateDto mission)
        {
            var miss = new Mission
            {
                Title = mission.Title,
                Date = DateTime.Now,
                Place = mission.Place,
                Description = mission.Description,
                EmployeeId = mission.EmployeeId,
                ProjectId = mission.ProjectId
            };
            await _wttDataAccess.SaveMissionAsync(miss);
            return miss.Id;
        }

        public async System.Threading.Tasks.Task  DeleteMission(int Id)
        {
            var mission = await _wttDataAccess.GetMissionAsync(Id);
            if (mission != null) 
            {
                throw new Exception("not found exception");
            }
            await _wttDataAccess.DeleteMissionAsync(mission);
        }

        public async  Task<MissionReadDto> GetMissionById(int Id)
        {
            var mission = await _wttDataAccess.GetMissionAsync(Id);
            return new MissionReadDto
            {
                Title = mission.Title,
                Place = mission.Place,
                Description = mission.Description,
                Date = mission.Date,
                ProjectId = mission.ProjectId,
                EmployeeId = mission.EmployeeId
            };
        }

        

        public async Task<List<MissionReadDto>> GetMissions(DateTime Date, int EmployeeId, int ProjectId, int pageNumer, int pageSize)
        {

            var mission = await _wttDataAccess.GetMissionsAsync(Date,EmployeeId,ProjectId, pageNumer, pageSize);
            return mission.Select(m => new MissionReadDto
            {
                Title = m.Title,
                Place = m.Place,
                Description = m.Description,
                Date = m.Date,
                ProjectId = m.ProjectId,
                EmployeeId = m.EmployeeId
            }).ToList();
        }

        public async System.Threading.Tasks.Task UpdateMission(MissionUpdateDto mission)
        {
            var miss = await _wttDataAccess.GetMissionAsync(mission.Id);
            if(miss==null)
            {
                throw new Exception("not found exception");
            }
            miss.Title=mission.Title;
            miss.ProjectId = mission.ProjectId;
            miss.Place = mission.Place;
            miss.Description = mission.Description;
            miss.Date = mission.Date;
            miss.EmployeeId = mission.EmployeeId;

            await _wttDataAccess.UpdateMissionAsync(miss);
        }
    }
}
