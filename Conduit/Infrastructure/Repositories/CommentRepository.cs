using Conduit.Models;
using Microsoft.EntityFrameworkCore;

namespace Conduit.Infrastructure.Repositories
{
    public class CommentRepository : ICommentRepository
    {
        private readonly ConduitDBContext conduitDbContext;

        public CommentRepository(ConduitDBContext conduitDbContext)
        {
            this.conduitDbContext = conduitDbContext ?? throw new ArgumentNullException(nameof(conduitDbContext));
        }
        public async Task AddComment(Comment comment)
        {
            await conduitDbContext.CommentTbls.AddAsync(comment);
        }

        public void DeleteComment(Comment comment)
        {
           conduitDbContext.CommentTbls.Remove(comment);
        }

        public async Task<IEnumerable<Comment>> GetArticleComments(int ArticleId)
        {
            return await conduitDbContext.CommentTbls.Where(comment => comment.ArticleId==ArticleId).ToListAsync();
        }

        public async Task<Comment?> GetComment(int CommentId)
        {
            return await conduitDbContext.CommentTbls.FirstOrDefaultAsync(comment => comment.CommentId == CommentId);
        }

        public async Task<IEnumerable<Comment>> GetUserComments(int UserId)
        {
            return await conduitDbContext.CommentTbls.Where(comment => comment.User.UserId == UserId).ToListAsync();
        }

        public async Task<bool> SaveChangesAsync()
        {
            return (await conduitDbContext.SaveChangesAsync() >= 0);
        }
    }
}
