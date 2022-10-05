using Conduit.Infrastructure.Repositories;
using Conduit.Models;
using ConduitTests.Mocks;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace ConduitTests
{
    public class CommentRepositoryTests
    {
        Mock<ICommentRepository> commentRepository = RepositoryMocks.GetCommentRepository();
        [Fact]
        public async void GetCommentTest()
        {
            Comment? comment = await commentRepository.Object.GetComment(2);
            Assert.NotNull(comment);
        }
        [Fact]
        public async void GetCommentNotFoundTest()
        {
            Comment? comment = await commentRepository.Object.GetComment(60);
            Assert.Null(comment);
        }
        [Fact]
        public async void AddCommentTest()
        {
            Random random = new Random();
            int rand = random.Next(100);
            Comment c = new Comment { CommentId = rand, ArticleId = 1, UserId = 1, BodyText = "WOO", date = DateTime.Now };
            await commentRepository.Object.AddComment(c);
            commentRepository.Verify(x => x.AddComment(c));
        }
        [Fact]
        public async void DeleteCommentTest()
        {
            Random random = new Random();
            int rand = random.Next(100);
            Comment c = new Comment { CommentId = 1, ArticleId = 1, UserId = 1, BodyText = "WOO", date = DateTime.Now };
            commentRepository.Object.DeleteComment(c);
            commentRepository.Verify(x => x.DeleteComment(c));
        }
        [Fact]
        public async void GetUserCommentsTest()
        {
            IEnumerable<Comment?> comments = await commentRepository.Object.GetUserComments(1);
            Assert.NotNull(comments);
            Assert.True(comments.Any());
        }
        [Fact]
        public async void GetArticleCommentsTest()
        {
            IEnumerable<Comment?> comments = await commentRepository.Object.GetUserComments(1);
            Assert.NotNull(comments);
            Assert.True(comments.Any());
        }
    }
}
