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
        private readonly UserForInsertValidator validator;

        public UserService(IUserRepository userRepository, IMapper mapper, UserForInsertValidator validator)
        {
            this.userRepository = userRepository ?? throw new ArgumentNullException(nameof(userRepository));
            this.mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            this.validator = validator ?? throw new ArgumentNullException(nameof(validator));
        }
        public async Task<bool> AddUserAsync(UserForInsertDTO userForInsert)
        {
            var userValidationResult = await validator.ValidateAsync(userForInsert);
            if (userValidationResult.IsValid)
            {
              User user =  mapper.Map<UserForInsertDTO, User>(userForInsert);
              await userRepository.AddUser(user);
             return await userRepository.SaveChangesAsync();
            }
            return false;
        }

        public async Task<UserDTO?> GetUserAsync(int UserId)
        {
           User? user = await userRepository.GetUser(UserId);
              if (user == null)
                return null;
           
            return mapper.Map<UserDTO>(user);
          
        }

        public async Task UpdateUserFullNameAsync(UserForUpdateDTO userForUpdate,
            User user)
        {
           mapper.Map(userForUpdate,user);
           await userRepository.SaveChangesAsync();
        }
    }
}
