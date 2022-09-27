using Conduit.Models;

namespace Conduit.Infrastructure.Repositories
{
    public interface IFavoriteArticlesRepository
    {
        public Task AddFavoriteArticle(FavoriteArticles favoriteArticles);
        public Task<IEnumerable<FavoriteArticles>> GetAllFavoriteArticles(int UserId);
        public void DeleteFavoriteArticle(FavoriteArticles favoriteArticle);
        public Task<bool> SaveChangesAsync();

    }
}
