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

namespace ConduitTests
{
    public class UserFollowerRepositoryTests
    {
        Mock<IFollowRepository> followerRepository = RepositoryMocks.GetUserFollowersRepository();
        [Fact]
        public async void GetFollower()
        {
            UserFollowers? follower = await followerRepository.Object.GetFollower(5);
            Assert.NotNull(follower);
        }
        [Fact]
        public async void GetFollowerNotFound()
        {
            UserFollowers? follower = await followerRepository.Object.GetFollower(50);
            Assert.Null(follower);
        }
        [Fact]
        public async void AddFollowerTest()
        {
            Random random = new Random();
            int rand = random.Next(100);
            UserFollowers u = new UserFollowers { UserFollowersId = rand, UserId = 5,FollowerId = 1 };
            await followerRepository.Object.AddFollower(u);
            followerRepository.Verify(x => x.AddFollower(u));
        }
        [Fact]
        public async void DeleteFollowerTest()
        {
            Random random = new Random();
            int rand = random.Next(100);
            UserFollowers a = new UserFollowers { UserFollowersId = 1, UserId = 5, FollowerId = 1 };
            followerRepository.Object.DeleteUserFollowers(a);
            followerRepository.Verify(x => x.DeleteUserFollowers(a));
        }
        [Fact]
        public async void GetFollowerTest()
        {
            IEnumerable<UserFollowers?> followers = await followerRepository.Object.GetAllUserFollowers(1);
            Assert.NotNull(followers);
            Assert.True(followers.Any());
        }
    }
}
