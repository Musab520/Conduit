using AutoMapper;
using Conduit.Core.DTOModels;
using Conduit.Core.Validators;
using Conduit.Infrastructure.Repositories;
using Conduit.Models;

namespace Conduit.Core.Services
{
    public class ArticleService : IArticleService
    {
        private readonly IArticleRepository articleRepository;
        private readonly IMapper mapper;

        public ArticleService(IArticleRepository articleRepository, IMapper mapper,ArticleForUpdateValidator validator)
        {
            this.articleRepository = articleRepository ?? throw new ArgumentNullException(nameof(articleRepository));
            this.mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }
        public async Task<ArticleDTO> AddArticleAsync(ArticleForInsertDTO articleForInsert)
        {
             Article article = mapper.Map<ArticleForInsertDTO, Article>(articleForInsert);
             await articleRepository.AddArticle(article);
             await articleRepository.SaveChangesAsync();
             return mapper.Map<ArticleDTO>(article);
        }
        public async Task<bool> DeleteArticle(ArticleDTO articleDTO)
        {
            articleRepository.ClearTracking();
            Article article = mapper.Map<Article>(articleDTO);
               articleRepository.DeleteArticle(article);
               return await articleRepository.SaveChangesAsync();
        }

        public async Task<ArticleDTO?> GetArticleAsync(int ArticleId)
        {
            Article? article= await articleRepository.GetArticle(ArticleId);
            if (article == null)
                return null;
            return mapper.Map<ArticleDTO>(article);
        }

        public async Task<IEnumerable<ArticleDTO>> GetUserArticlesAsync(int UserId)
        {
           IEnumerable<Article> articles=await articleRepository.GetUserArticles(UserId);
           return mapper.Map<IEnumerable<ArticleDTO>>(articles);
        }

        public async Task UpdateArticleAsync(ArticleForUpdateDTO articleForUpdate,int ArticleId)
        {
                Article article = await articleRepository.GetArticle(ArticleId);
                mapper.Map(articleForUpdate, article);
                await articleRepository.SaveChangesAsync();
              
       
        }
    }
}
