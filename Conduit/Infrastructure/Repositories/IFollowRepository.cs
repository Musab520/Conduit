using Conduit.Models;

namespace Conduit.Infrastructure.Repositories
{
    public interface IFollowRepository
    {
        public Task AddFollower(UserFollowers userFollowers);
        public Task<IEnumerable<UserFollowers>> GetAllUserFollowers(int UserId);
        public void DeleteUserFollowers(UserFollowers userFollower);
        public Task<bool> SaveChangesAsync();
    }
}
