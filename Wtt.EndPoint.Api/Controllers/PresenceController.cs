using Microsoft.AspNetCore.Mvc;
using Wtt.Services.Dto.Presence;
using Wtt.Services.Interfaces;

namespace Wtt.EndPoint.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PresenceController
    {


        private readonly ILogger<PresenceController> _logger;
        private readonly IPresenceService _presenceService;

        public PresenceController(ILogger<PresenceController> logger, IPresenceService presenceService)
        {
            _logger = logger;
            _presenceService = presenceService;
        }
        [HttpPost]
        public async Task<int> AddPresence(PresenceCreateDto presence)
        {
            return await _presenceService.AddPresence(presence);
        }

        [HttpDelete]
        //public async System.Threading.Tasks.Task DeletePresence(int Id)
        //{
            //await _presenceService.DeletePresence(Id);
        //}

        [HttpGet]
        public async Task<PresenceReadDto> GetPresenceById(int Id)
        {
            return await _presenceService.GetPresenceById(Id);
        }

        [HttpGet("all")]
        public async Task<List<PresenceReadDto>> GetPresences(int EmployeeId, DateTime Starttime, DateTime Endtime, int pageNumber, int pageSize)
        {
            return await _presenceService.GetPresences(EmployeeId, Starttime, Endtime, pageNumber, pageSize);
        }

        [HttpPut]
        public async System.Threading.Tasks.Task UpdatePresence(PresenceUpdateDto presence)
        {
            await _presenceService.UpdatePresence(presence);
        }
    }
}
