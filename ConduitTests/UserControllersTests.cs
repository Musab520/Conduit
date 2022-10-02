using AutoMapper;
using Conduit.Core.Services;
using Conduit.Infrastructure.Repositories;
using Conduit.Models;
using ConduitTests.Mocks;
using Moq;
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
    }
}