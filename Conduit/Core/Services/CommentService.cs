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
        private readonly CommentForInsertValidator validator;

        public CommentService(ICommentRepository commentRepository, IMapper mapper, CommentForInsertValidator validator)
        {
            this.commentRepository = commentRepository ?? throw new ArgumentNullException(nameof(commentRepository));
            this.mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            this.validator = validator ?? throw new ArgumentNullException(nameof(validator));
        }
        public async Task<bool> AddComment(CommentForInsertDTO commentForInsert)
        {
            var commentValidationResult = await validator.ValidateAsync(commentForInsert);
            if (commentValidationResult.IsValid)
            {
                Comment comment = mapper.Map<CommentForInsertDTO, Comment>(commentForInsert);
                await commentRepository.AddComment(comment);
                return await commentRepository.SaveChangesAsync();
            }
            return false;
        }
        public async Task<bool> DeleteComment(CommentDTO commentDTO)
        {
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
