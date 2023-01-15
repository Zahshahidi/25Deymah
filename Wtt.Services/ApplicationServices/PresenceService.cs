using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Wtt.DataAccess;
using Wtt.Domain.Entities;
using Wtt.Services.Dto.Presence;
using Wtt.Services.Interfaces;

namespace Wtt.Services.ApplicationServices
{
    internal class PresenceService : IPresenceService
    {
        private readonly IWttDataAccess _wttDataAccess;

        public PresenceService(IWttDataAccess wttDataAccess)
        {
            _wttDataAccess = wttDataAccess;
        }
        public async Task<int> AddPresence(PresenceCreateDto presence)
        {
            var pre = new Presence
            {
                EmployeeId = presence.EmployeeId,
                Starttime = presence.Starttime,
                Endtime = presence.Endtime,
                Description = presence.Description
            };
            await _wttDataAccess.SavePresenceAsynce(pre);
            return pre.Id;
        }

        public async Task<PresenceReadDto> GetPresenceById(int Id)
        {
            var presence = await _wttDataAccess.GetPresenceAsync(Id);
            return new PresenceReadDto
            {
                Id = presence.Id,
                EmployeeId = presence.EmployeeId,
                Starttime = presence.Starttime,
                Endtime = presence.Endtime,
                Description = presence.Description

            };
        }

        public async Task<List<PresenceReadDto>> GetPresences(int EmployeeId, DateTime Starttime, DateTime Endtime, int pageNumber, int pageSize)
        {
            var presence = await _wttDataAccess.GetPresencesAsync(EmployeeId,Starttime,Endtime, pageNumber, pageSize);
            return presence.Select(p => new PresenceReadDto
            {
                Id = p.Id,
                EmployeeId = p.EmployeeId,
                Starttime = p.Starttime,
                Endtime = p.Endtime,
                Description = p.Description

            }).ToList();
        }

        public async System.Threading.Tasks.Task  UpdatePresence(PresenceUpdateDto presence)
        {
            var pre = await _wttDataAccess.GetPresenceAsync(presence.Id);
            if(pre==null)
            {
                throw new Exception("not fouvd new exception");
            }
            pre.Id = presence.Id;
            pre.EmployeeId = presence.EmployeeId;
            pre.Starttime = presence.Starttime;
            pre.Endtime = presence.Endtime;
            pre.Description = presence.Description;

            await _wttDataAccess.UpdatePresenceAsync(pre);

        }
        //public async System.Threading.Tasks.Task DeletePresence(int Id)
        //{
            //var presence = await _wttDataAccess.GetPresenceAsync(Id);
            //if (presence != null)
            //{
                //throw new Exception("not found exception");
            //}
            //await _wttDataAccess.DeletePresenceAsync(presence);
        //}
    }
}
