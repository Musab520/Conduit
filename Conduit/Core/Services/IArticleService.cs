using Conduit.Core.DTOModels;
using Conduit.Models;

namespace Conduit.Core.Services
{
    public interface IArticleService
    {
        public Task AddArticleAsync(ArticleForInsertDTO article);
        public Task<ArticleDTO?> GetArticleAsync(int ArticleId);
        public Task<IEnumerable<ArticleDTO>> GetUserArticlesAsync(int UserId);
        public Task<bool> DeleteArticle(ArticleDTO article);
        public Task<bool> UpdateArticleAsync(ArticleForUpdateDTO articleForUpdate,Article article);
    }
}
