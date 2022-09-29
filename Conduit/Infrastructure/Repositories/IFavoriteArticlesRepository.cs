using Conduit.Models;

namespace Conduit.Infrastructure.Repositories
{
    public interface IFavoriteArticlesRepository
    {
        public Task AddFavoriteArticle(FavoriteArticles favoriteArticles);
        public Task<IEnumerable<FavoriteArticles>> GetAllFavoriteArticles(int UserId);
        public Task<FavoriteArticles?> GetFavoriteArticle(int favoriteArticleId);
        public void DeleteFavoriteArticle(FavoriteArticles favoriteArticle);
        public Task<bool> SaveChangesAsync();

    }
}
