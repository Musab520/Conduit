using AutoMapper;
using Conduit.Core.DTOModels;
using Conduit.Core.Mappers;
using Conduit.Core.Services;
using Conduit.Infrastructure.Repositories;
using Conduit.Models;
using ConduitTests.Mocks;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace ConduitTests.ServiceTests
{
    public class UserServiceTest
    {
        private readonly IUserService userService;
        public UserServiceTest()
        {
            this.userService = new UserService(RepositoryMocks.GetUserRepository().Object,MapperMocks.GetMockMapper().Object);
        }

        [Fact]  
        public async Task CreateUserTest()
        {
            UserForInsertDTO userForInsertDTO = new UserForInsertDTO { Username="Karma",Password="yoyoyo",FullName="Karma"};
            UserDTO? userDTO=await userService.AddUserAsync(userForInsertDTO);
            Assert.NotNull(userDTO);
        }
        [Fact]
        public async Task GetUserTest()
        {
           UserDTO? userDTO = await userService.GetUserAsync(1);
           Assert.NotNull(userDTO);
        }
        [Fact]
        public async Task GetUserNotFoundTest()
        {
            UserDTO? userDTO = await userService.GetUserAsync(100);
            Assert.Null(userDTO);
        }
        [Fact]
        public async Task UpdateUserTest()
        {
            UserForUpdateDTO userForUpdateDTO = new UserForUpdateDTO { Username = "musab", Password = "yoyoyo", FullName = "Karma" };
            UserDTO? userDTO = await userService.UpdateUserAsync(userForUpdateDTO, 2);
            Assert.NotNull(userDTO);
        }


    }
}
