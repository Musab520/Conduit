using Conduit.Models;
using Microsoft.EntityFrameworkCore;

namespace Conduit.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly ConduitDBContext conduitDbContext;

        public UserRepository(ConduitDBContext conduitDbContext)
        {
            this.conduitDbContext = conduitDbContext;    
        }
        public async Task AddUser(User user)
        {
            await conduitDbContext.UserTbls.AddAsync(user);
        }
        public async Task<User?> GetUser(int UserId)
        {
            return await conduitDbContext.UserTbls.FirstOrDefaultAsync(user => user.UserId == UserId);
        }
        public async Task<bool> SaveChangesAsync()
        {
            return (await  conduitDbContext.SaveChangesAsync() >= 0);
        }
    }
}
