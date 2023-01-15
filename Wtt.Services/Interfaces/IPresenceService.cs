using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wtt.Services.Dto.Mission;
using Wtt.Services.Dto.Presence;

namespace Wtt.Services.Interfaces
{
    public interface IPresenceService
    {
        Task<int> AddPresence(PresenceCreateDto presence);
        Task UpdatePresence(PresenceUpdateDto presence);
        //Task DeletePresence(int Id);
        Task<PresenceReadDto> GetPresenceById(int Id);
        Task<List<PresenceReadDto>> GetPresences(int EmployeeId, DateTime Starttime, DateTime Endtime, int pageNumber, int pageSize);

    }
}
