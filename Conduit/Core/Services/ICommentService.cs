using Conduit.Core.DTOModels;

namespace Conduit.Core.Services
{
    public interface ICommentService
    {
        public Task<CommentDTO> AddComment(CommentForInsertDTO comment);
        public Task<CommentDTO?> GetComment(int CommentId);
        public Task<IEnumerable<CommentDTO>> GetArticleComments(int ArticleId);
        public Task<IEnumerable<CommentDTO>> GetUserComments(int UserId);
        public Task<bool> DeleteComment(CommentDTO commentDTO);
    }
}
