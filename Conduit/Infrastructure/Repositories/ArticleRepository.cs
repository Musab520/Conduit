using Conduit.Models;
using Microsoft.EntityFrameworkCore;

namespace Conduit.Infrastructure.Repositories
{
    
    public class ArticleRepository : IArticleRepository
    {
        private readonly ConduitDBContext conduitDbContext;

        public ArticleRepository(ConduitDBContext conduitDbContext)
        {
            this.conduitDbContext = conduitDbContext;
        }
        public async Task AddArticle(Article article)
        {
            await conduitDbContext.ArticleTbls.AddAsync(article);
        }

        public void DeleteArticle(Article article)
        {
             conduitDbContext.ArticleTbls.Remove(article);
        }

        public async Task<Article?> GetArticle(int ArticleId)
        {
            return await conduitDbContext.ArticleTbls.FirstOrDefaultAsync(article => article.ArticleId == ArticleId);
        }
        public async Task<IEnumerable<Article>> GetUserArticles(int UserId)
        {
            return await conduitDbContext.ArticleTbls.Where(article=>article.User.UserId==UserId).ToListAsync();
        }
        public async Task<bool> SaveChangesAsync()
        {
            return (await conduitDbContext.SaveChangesAsync() >= 0);
        }
    }
}
