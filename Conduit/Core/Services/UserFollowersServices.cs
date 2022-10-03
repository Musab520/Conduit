using AutoMapper;
using Conduit.Core.DTOModels;
using Conduit.Core.Validators;
using Conduit.Infrastructure.Repositories;
using Conduit.Models;

namespace Conduit.Core.Services
{
    public class UserFollowersServices : IUserFollowersService
    {
        private readonly IFollowRepository userFollowersRepository;
        private readonly IMapper mapper;

        public UserFollowersServices(IFollowRepository userFollowersRepository,IMapper mapper)
        {
            this.userFollowersRepository = userFollowersRepository ?? throw new ArgumentNullException(nameof(userFollowersRepository));
            this.mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }
        public async Task<FollowerDTO> AddFollower(FollowersForInsertDTO followerForInsert)
        {
            UserFollowers follower = mapper.Map<UserFollowers>(followerForInsert);
            await userFollowersRepository.AddFollower(follower);
            await userFollowersRepository.SaveChangesAsync();
            return mapper.Map<FollowerDTO>(follower);
        }
        public async Task<bool> DeleteUserFollowers(FollowerDTO followerDTO)
        {
            userFollowersRepository.ClearTracking();
            UserFollowers? follower = mapper.Map<UserFollowers>(followerDTO);
            userFollowersRepository.DeleteUserFollowers(follower);
            return await userFollowersRepository.SaveChangesAsync();
        }
        public async Task<IEnumerable<FollowerDTO>> GetAllUserFollowers(int UserId)
        {
            IEnumerable<UserFollowers> userFollowers= await userFollowersRepository.GetAllUserFollowers(UserId);
            return mapper.Map<IEnumerable<FollowerDTO>>(userFollowers);
        }

        public async Task<FollowerDTO?> GetFollower(int userFollowerId)
        {
           UserFollowers? follower= await userFollowersRepository.GetFollower(userFollowerId);
            if (follower == null)
                return null;
           return mapper.Map<FollowerDTO>(follower);
        }
    }
}
