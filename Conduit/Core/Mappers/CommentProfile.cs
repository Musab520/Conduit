using AutoMapper;
using Conduit.Core.DTOModels;
using Conduit.Models;

namespace Conduit.Core.Mappers
{
    public class CommentProfile : Profile
    {
        public CommentProfile()
        {
            CreateMap<CommentDTO,Comment>();
            CreateMap<CommentForInsertDTO, Comment>();
        }
    }
}
