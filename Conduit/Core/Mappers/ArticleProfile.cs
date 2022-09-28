using AutoMapper;
using Conduit.Core.DTOModels;
using Conduit.Models;

namespace Conduit.Core.Mappers
{
    public class ArticleProfile:Profile
    {
        public ArticleProfile()
        {
            CreateMap<ArticleDTO, Article>();
            CreateMap<ArticleForInsertDTO, Article>();
        }
    }
}
