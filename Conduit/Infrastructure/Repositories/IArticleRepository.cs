using Conduit.Models;

namespace Conduit.Infrastructure.Repositories
{
    public interface IArticleRepository
    {
        public Task AddArticle(Article article);
        public Task<Article> GetArticle(int ArticleId);
        public Task<IEnumerable<Article>> GetUserArticles(int UserId);
        public Task UpdateArticle(int ArticleId, Article article);
        public Task DeleteArticle(int ArticleId);
    }
}
