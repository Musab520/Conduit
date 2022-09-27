using Conduit.Models;

namespace Conduit.Infrastructure.Repositories
{
    public interface IUserRepository
    {
        public Task AddUser(User user);
        public Task<User> GetUser(int UserId);
        public Task UpdateUser(int UserId, User user);
    }
    
}
