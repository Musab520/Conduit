using AutoMapper;
using Conduit.Core.DTOModels;
using Conduit.Infrastructure.Repositories;
using Conduit.Models;

namespace Conduit.Core.Services
{
    public class FavoriteArticleService : IFavoriteArticleService
    {
        private readonly IFavoriteArticlesRepository favoriteArticlesRepository;
        private readonly IMapper mapper;

        public FavoriteArticleService(IFavoriteArticlesRepository favoriteArticlesRepository,IMapper mapper)
        {
            this.favoriteArticlesRepository = favoriteArticlesRepository ?? throw new ArgumentNullException(nameof(favoriteArticlesRepository));
            this.mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }
        public async Task AddFavoriteArticle(FavoriteArticlesForInsertDTO favoriteArticle)
        {
            FavoriteArticles favorite = mapper.Map<FavoriteArticles>(favoriteArticle);
            await favoriteArticlesRepository.AddFavoriteArticle(favorite);
            await favoriteArticlesRepository.AddFavoriteArticle(favorite);
        }

        public async Task<bool> DeleteFavoriteArticle(FavoriteArticlesDTO favoriteDTO)
        {
            FavoriteArticles? favorite= mapper.Map<FavoriteArticles>(favoriteDTO);
            favoriteArticlesRepository.DeleteFavoriteArticle(favorite);
            return await favoriteArticlesRepository.SaveChangesAsync();
        }

        public async Task<IEnumerable<FavoriteArticlesDTO>> GetAllFavoriteArticles(int UserId)
        {
            IEnumerable<FavoriteArticles> favArticles = await favoriteArticlesRepository.GetAllFavoriteArticles(UserId);
            return mapper.Map<IEnumerable<FavoriteArticlesDTO>>(favArticles);
        }

        public async Task<FavoriteArticlesDTO?> GetFavoriteArticle(int favoriteArticleId)
        {
            FavoriteArticles? favArticle = await favoriteArticlesRepository.GetFavoriteArticle(favoriteArticleId);
            if (favArticle == null)
                return null;
            return mapper.Map<FavoriteArticlesDTO>(favArticle);
        }
    }
}
