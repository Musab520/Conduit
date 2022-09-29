using AutoMapper;
using Conduit.Core.DTOModels;
using Conduit.Models;

namespace Conduit.Core.Mappers
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<UserDTO, User>();
            CreateMap<User, UserDTO>();
            CreateMap<User, UserForUpdateDTO>();
            CreateMap<UserForUpdateDTO,User>();
            CreateMap<UserForInsertDTO, User>();

        }
    }
}
