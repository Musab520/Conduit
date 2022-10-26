using Conduit.Models;

namespace Conduit.Infrastructure.Repositories
{
    public interface ICommentRepository
    {
        public Task AddComment(Comment comment);
        public Task<Comment?> GetComment(int CommentId);
        public Task<IEnumerable<Comment>> GetArticleComments(int ArticleId);
        public Task<IEnumerable<Comment>> GetUserComments(int UserId);
        public void DeleteComment(Comment comment);
        public Task<bool> SaveChangesAsync();
        public void ClearTracking();
       
    }
}
