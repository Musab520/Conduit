using Conduit.Core.DTOModels;
using Conduit.Infrastructure.Repositories;
using Conduit.Models;
using Microsoft.AspNetCore.JsonPatch;

namespace Conduit.Core.Services
{
    public interface IUserService
    {
        public Task<bool> AddUserAsync(UserForInsertDTO userforInsert);
        public Task<UserDTO?> GetUserAsync(int UserId);
        public Task UpdateUserFullNameAsync(UserForUpdateDTO userForUpdateDTO,User user);
    }
}
