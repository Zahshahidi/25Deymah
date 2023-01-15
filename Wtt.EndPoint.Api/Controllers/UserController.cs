using Microsoft.AspNetCore.Mvc;
using Wtt.Services.Dto.User;
using Wtt.Services.Interfaces;

namespace Wtt.EndPoint.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController
    {
        private readonly ILogger<UserController> _logger;
        private readonly IUserService _userService;

        public UserController(ILogger<UserController> logger, IUserService userService)
        {
            _logger = logger;
            _userService = userService;
        }
        [HttpPost]
        //public async Task<int> AddUser(UserCreateDto user)
        //{
        //return await _userService.AddUser(user);
        //}

        [HttpDelete]
        public async System.Threading.Tasks.Task DeleteUser(string username)
        {
            await _userService.DeleteUser(username);
        }

        [HttpGet]
        public async Task<UserReadDto> GetUserById(string username)
        {
            return await _userService.GetUserByUsername(username);
        }

        [HttpGet("all")]
        public async Task<List<UserReadDto>> GetUsers(string username, int pageNumber, int pageSize)
        {
            return await _userService.GetUsers(username, pageNumber, pageSize);
        }

        [HttpPut]
        public async System.Threading.Tasks.Task UpdateUser(UserUpdateDto user)
        {
            await _userService.UpdateUser(user);
        }
    }
}
