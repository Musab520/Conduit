using Conduit.Models;

namespace Conduit.Infrastructure.Repositories
{
    public interface IUserRepository
    {
        public Task AddUser(User user);
        public Task<User?> GetUser(int UserId);
        public Task<User?> GetUserFromUsername(string Username);
        public Task<bool> SaveChangesAsync();
    }
    
}
