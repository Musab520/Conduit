using Conduit.Core.DTOModels;
using Conduit.Infrastructure.Repositories;
using Conduit.Models;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace Conduit.Core.Services
{
    public interface IUserService
    {
        public Task<UserDTO?> AddUserAsync(UserForInsertDTO userforInsert);
        public Task<UserDTO?> GetUserAsync(int UserId);
        public Task UpdateUserAsync(UserForUpdateDTO userForUpdateDTO,int UserId);
    }
}
