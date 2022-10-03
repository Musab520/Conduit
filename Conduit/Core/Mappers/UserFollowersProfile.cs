using AutoMapper;
using Conduit.Core.DTOModels;
using Conduit.Models;

namespace Conduit.Core.Mappers
{
    public class UserFollowersProfile:Profile
    {
        public UserFollowersProfile()
        {
            CreateMap<FollowerDTO, UserFollowers>();
            CreateMap<UserFollowers,FollowerDTO>();
            CreateMap<FollowersForInsertDTO, UserFollowers>();
        }
    }
}
