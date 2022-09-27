﻿using Conduit.Models;

namespace Conduit.Infrastructure.Repositories
{
    public interface ICommentRepository
    {
        public Task AddComment(Comment comment);
        public Task<Comment> GetComment(int CommentId);
        public Task<IEnumerable<Comment>> GetUserComments(int UserId);
        public Task DeleteComment(int CommentId);
        public Task<bool> SaveChangesAsync();
    }
}
