using Conduit.Models;

namespace Conduit.Infrastructure.Repositories
{
    public interface IArticleRepository
    {
        public Task AddArticle(Article article);
        public Task<Article?> GetArticle(int ArticleId);
        public Task<IEnumerable<Article>> GetUserArticles(int UserId);
        public void DeleteArticle(Article article);
        public Task<bool> SaveChangesAsync();
        public void ClearTracking();
    }
}
