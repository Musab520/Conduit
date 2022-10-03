using AutoMapper;
using Conduit.Core.DTOModels;
using Conduit.Core.Validators;
using Conduit.Infrastructure.Repositories;
using Conduit.Models;
using FluentValidation;
using Microsoft.AspNetCore.JsonPatch;


namespace Conduit.Core.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository userRepository;
        private readonly IMapper mapper;
        

        public UserService(IUserRepository userRepository, IMapper mapper)
        {
            this.userRepository = userRepository ?? throw new ArgumentNullException(nameof(userRepository));
            this.mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            
        }
        public async Task<UserDTO?> AddUserAsync(UserForInsertDTO userForInsert)
        {
              User user =  mapper.Map<UserForInsertDTO, User>(userForInsert);
              await userRepository.AddUser(user);
              await userRepository.SaveChangesAsync();
              return mapper.Map<UserDTO>(user);
        }

        public async Task<UserDTO?> GetUserAsync(int UserId)
        {
           User? user = await userRepository.GetUser(UserId);
            if (user == null)
            {
                return null;
            }
            return mapper.Map<UserDTO>(user);
          
        }
        public async Task<UserDTO?> GetUserFromUserName(string username)
        {
            User? user = await userRepository.GetUserFromUsername(username);
            if(user == null)
            {
                return null;
            }
            return mapper.Map<UserDTO>(user);
        }

        public async Task UpdateUserAsync(UserForUpdateDTO userForUpdate,int UserId)
        {
            User user = await userRepository.GetUser(UserId);
            mapper.Map(userForUpdate,user);
            await userRepository.SaveChangesAsync();
        }
    }
}
