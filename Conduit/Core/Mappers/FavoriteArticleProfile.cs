using AutoMapper;
using Conduit.Core.DTOModels;
using Conduit.Models;

namespace Conduit.Core.Mappers
{
    public class FavoriteArticleProfile:Profile
    {
        public FavoriteArticleProfile()
        {
            CreateMap<FavoriteArticlesDTO,FavoriteArticles>();
            CreateMap<FavoriteArticlesForInsertDTO, FavoriteArticles>();
        }
    }
}
