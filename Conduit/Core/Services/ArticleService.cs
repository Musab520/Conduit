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
        private readonly ArticleForUpdateValidator validator;

        public ArticleService(IArticleRepository articleRepository, IMapper mapper,ArticleForUpdateValidator validator)
        {
            this.articleRepository = articleRepository ?? throw new ArgumentNullException(nameof(articleRepository));
            this.mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            this.validator = validator ?? throw new ArgumentNullException(nameof(validator));
        }
        public async Task AddArticleAsync(ArticleForInsertDTO articleForInsert)
        {
             Article article = mapper.Map<ArticleForInsertDTO, Article>(articleForInsert);
             await articleRepository.AddArticle(article);
             await articleRepository.SaveChangesAsync();
        }
        public async Task<bool> DeleteArticle(ArticleDTO articleDTO)
        {
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

        public async Task<bool> UpdateArticleAsync(ArticleForUpdateDTO articleForUpdate,Article article)
        {
            var articleForUpdateValidatorResult= validator.Validate(articleForUpdate);
            if (articleForUpdateValidatorResult.IsValid)
            {
                mapper.Map(articleForUpdate, article);
                return await articleRepository.SaveChangesAsync();
            }
            return false;
        }
    }
}
