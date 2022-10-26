using Conduit.Core.DTOModels;

namespace Conduit.Core.Services
{
    public interface IUserFollowersService
    {
        public Task<FollowerDTO?> GetFollower(int userFollowerId);
        public Task<FollowerDTO> AddFollower(FollowersForInsertDTO userFollowers);
        public Task<IEnumerable<FollowerDTO>> GetAllUserFollowers(int UserId);
        public Task<bool> DeleteUserFollowers(FollowerDTO follower);
    }
}
