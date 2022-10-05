using AutoMapper;
using Conduit.Core.DTOModels;
using Conduit.Models;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConduitTests.Mocks
{
    public class MapperMocks
    {
        public static Mock<IMapper> GetMockMapper()
        {
            var mockMapper = new Mock<IMapper>();
            mockMapper.Setup(x => x.Map<UserForInsertDTO, User>(It.IsAny<UserForInsertDTO>()))
                 .Returns((UserForInsertDTO user) => new User { Username = user.Username, Password = user.Password, FullName = user.FullName });
            mockMapper.Setup(x => x.Map<User, UserDTO>(It.IsAny<User>()))
                .Returns((User user) => new UserDTO { UserId = user.UserId, Username = user.Username, Password = user.Password, FullName = user.FullName });
            mockMapper.Setup(x => x.Map<UserDTO, User>(It.IsAny<UserDTO>()))
                .Returns((UserDTO user) => new User { UserId = user.UserId, Username = user.Username, Password = user.Password, FullName = user.FullName });
            mockMapper.Setup(x => x.Map<UserForUpdateDTO, User>(It.IsAny<UserForUpdateDTO>())).Returns((UserForUpdateDTO userUpdate)=>new User { Username=userUpdate.Username,Password=userUpdate.Password,FullName=userUpdate.FullName});
            return mockMapper;
        }
    }
}
