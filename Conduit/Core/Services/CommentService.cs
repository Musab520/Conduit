using AutoMapper;
using Conduit.Core.DTOModels;
using Conduit.Core.Validators;
using Conduit.Infrastructure.Repositories;
using Conduit.Models;

namespace Conduit.Core.Services
{
    public class CommentService : ICommentService
    {
        private readonly ICommentRepository commentRepository;
        private readonly IMapper mapper;


        public CommentService(ICommentRepository commentRepository, IMapper mapper, CommentForInsertValidator validator)
        {
            this.commentRepository = commentRepository ?? throw new ArgumentNullException(nameof(commentRepository));
            this.mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
           
        }
        public async Task<CommentDTO> AddComment(CommentForInsertDTO commentForInsert)
        {
      
                Comment comment = mapper.Map<CommentForInsertDTO, Comment>(commentForInsert);
                await commentRepository.AddComment(comment);
                await commentRepository.SaveChangesAsync();
                return mapper.Map<CommentDTO>(comment);
         
        }
        public async Task<bool> DeleteComment(CommentDTO commentDTO)
        {
            commentRepository.ClearTracking();
            Comment? comment = mapper.Map<Comment>(commentDTO);
           
                commentRepository.DeleteComment(comment);
               return  await commentRepository.SaveChangesAsync();
 
        }

        public async Task<IEnumerable<CommentDTO>> GetArticleComments(int ArticleId)
        {
           IEnumerable<Comment> comments= await commentRepository.GetArticleComments(ArticleId);   
           return mapper.Map<IEnumerable<CommentDTO>>(comments);
        }

        public async Task<CommentDTO?> GetComment(int CommentId)
        {
            Comment? comment = await commentRepository.GetComment(CommentId);
            if (comment == null)
            {
                return null;
            }
            return mapper.Map<CommentDTO?>(comment);
        }

        public async Task<IEnumerable<CommentDTO>> GetUserComments(int UserId)
        {
            IEnumerable<Comment> comments = await commentRepository.GetUserComments(UserId);
            return mapper.Map<IEnumerable<CommentDTO>>(comments);
        }
    }
}
