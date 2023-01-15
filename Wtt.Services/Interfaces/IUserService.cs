using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wtt.Services.Dto;
using Wtt.Services.Dto.User;

namespace Wtt.Services.Interfaces
{
    public interface IUserService
    {        
        Task UpdateUser(UserUpdateDto user);
        Task DeleteUser(string username);
        Task<UserReadDto> GetUserByUsername(string username);
        Task<List<UserReadDto>> GetUsers(string username, int pageNumber, int pageSize);
    }
}
