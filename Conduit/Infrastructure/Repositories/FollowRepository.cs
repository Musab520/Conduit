using Conduit.Models;
using Microsoft.EntityFrameworkCore;

namespace Conduit.Infrastructure.Repositories
{
    public class FollowRepository : IFollowRepository
    {
        private readonly ConduitDBContext conduitDbContext;

        public FollowRepository(ConduitDBContext conduitDbContext)
        {
            this.conduitDbContext = conduitDbContext;
        }
        public async Task AddFollower(UserFollowers userFollower)
        {
            await conduitDbContext.UserFollowersTbls.AddAsync(userFollower);
        }

        public void DeleteUserFollowers(UserFollowers userFollower)
        {
            conduitDbContext.UserFollowersTbls.Remove(userFollower);
        }

        public async Task<IEnumerable<UserFollowers>> GetAllUserFollowers(int UserId)
        {
            return await conduitDbContext.UserFollowersTbls.Where(follower=>follower.UserId==UserId).ToListAsync();
        }

        public async Task<bool> SaveChangesAsync()
        {
            return (await conduitDbContext.SaveChangesAsync() >= 0);
        }
    }
}
