using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wtt.DataAccess;
using Wtt.Services.Dto.User;
using Wtt.Services.Interfaces;

namespace Wtt.Services.ApplicationServices
{
    internal class UserService : IUserService
    {
        private readonly IWttDataAccess _wttDataAccess;

        public UserService(IWttDataAccess wttDataAccess)
        {
            _wttDataAccess = wttDataAccess;
        }
        public async System.Threading.Tasks.Task  DeleteUser(string username)
        {
            var user = await _wttDataAccess.GetUserAsync(username);
            if(user==null)
            {
                throw new Exception("not found new exception");
            }
            await _wttDataAccess.DeleteUserAsync(user);
        }

        public async Task<UserReadDto> GetUserByUsername(string username)
        {
            var user = await _wttDataAccess.GetUserAsync(username);
            return new UserReadDto
            {
                Username = user.Username,
                Password = user.Password
            };
        }

        public async Task<List<UserReadDto>> GetUsers(string username,int pageNumber,int pageSize)
        {
            var users = await _wttDataAccess.GetUsersAsync(username, pageNumber,pageSize);
            return users.Select(u => new UserReadDto
            { Username = u.Username,
            Password= u.Password
            }).ToList();

        }

        public async System.Threading.Tasks.Task UpdateUser(UserUpdateDto user)
        {
            var use = await _wttDataAccess.GetUserAsync(user.Username);
            if(use==null)
            {
                throw new Exception("not found new exception");
            }
            use.Username=user.Username;
            use.Password=user.Password;

            await _wttDataAccess.UpdateUserAsync(use);
        }
    }
}
