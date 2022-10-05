using Conduit.Infrastructure.Repositories;
using ConduitTests.Mocks;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConduitTests.ServiceTests
{
    public class UserServiceTest
    {
        Mock<IUserRepository> userRepository = RepositoryMocks.GetUserRepository();
        
        
    }
}
