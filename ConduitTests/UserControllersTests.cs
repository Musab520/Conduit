using AutoMapper;
using Conduit.Core.Services;
using Conduit.Infrastructure.Repositories;
using Conduit.Models;
using ConduitTests.Mocks;
using Moq;
using System;
using System.Threading.Tasks;
using Xunit;

namespace ConduitTests
{
    public class UserControllerTests
    {
        Mock<IUserRepository> userRepository = RepositoryMocks.GetUserRepository();
      
        [Fact]
        public async void GetUserTest()
        {
            User? user = await userRepository.Object.GetUser(2);
            Assert.NotNull(user);
        }
        [Fact]
        public async void GetUserNotFoundTest()
        {
            User? user = await userRepository.Object.GetUser(10);
            Assert.Null(user);
        }
        [Fact]
        public async void GetUserFromUsernameTest()
        {
            User? user = await userRepository.Object.GetUserFromUsername("mazen");
            Assert.NotNull(user);
        }
        [Fact]
        public async void GetUserFromUsernameNotFoundTest()
        {
            User? user = await userRepository.Object.GetUserFromUsername("jokerman");
            Assert.Null(user);
        }
        [Fact]
        public async void AddUserTest()
        {
            Random random = new Random();
            int rand = random.Next(100);
            User u = new User { UserId = rand, Username = "dummy" + rand, Password = "dummy123", FullName = "Dummy Dum Dum" };
            await userRepository.Object.AddUser(u);
            userRepository.Verify(x => x.AddUser(u));
        }
    }
}