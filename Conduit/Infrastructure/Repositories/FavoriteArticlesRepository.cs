using Conduit.Models;
using Microsoft.EntityFrameworkCore;

namespace Conduit.Infrastructure.Repositories
{
    public class FavoriteArticlesRepository : IFavoriteArticlesRepository
    {
        private readonly ConduitDBContext conduitDbContext;

        public FavoriteArticlesRepository(ConduitDBContext conduitDbContext)
        {
            this.conduitDbContext= conduitDbContext ?? throw new ArgumentNullException(nameof(conduitDbContext));
       
        }
        public async Task AddFavoriteArticle(FavoriteArticles favoriteArticles)
        {
            await conduitDbContext.FavoriteArticlesTbls.AddAsync(favoriteArticles);
        }

        public void DeleteFavoriteArticle(FavoriteArticles favoriteArticle)
        {
            conduitDbContext.FavoriteArticlesTbls.Remove(favoriteArticle);
        }

        public async Task<IEnumerable<FavoriteArticles>> GetAllFavoriteArticles(int UserId)
        {
            return await conduitDbContext.FavoriteArticlesTbls.Where(favorite => favorite.UserId == UserId).ToListAsync();
        }

        public async Task<FavoriteArticles?> GetFavoriteArticle(int favoriteArticleId)
        {
            return await conduitDbContext.FavoriteArticlesTbls.FirstOrDefaultAsync(article=>article.FavoriteArticlesId==favoriteArticleId);   
        }

        public async Task<bool> SaveChangesAsync()
        {
            return (await conduitDbContext.SaveChangesAsync() >= 0);
        }
    }
}
