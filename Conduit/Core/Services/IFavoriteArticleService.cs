using Conduit.Core.DTOModels;
using Conduit.Models;

namespace Conduit.Core.Services
{
    public interface IFavoriteArticleService
    {
        public Task AddFavoriteArticle(FavoriteArticlesForInsertDTO favoriteArticles);
        public Task<IEnumerable<FavoriteArticlesDTO>> GetAllFavoriteArticles(int UserId);
        public Task<FavoriteArticlesDTO?> GetFavoriteArticle(int favoriteArticleId);
        public Task<bool> DeleteFavoriteArticle(FavoriteArticlesDTO favorite);
    }
}
