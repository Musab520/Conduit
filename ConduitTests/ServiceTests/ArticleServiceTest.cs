using Conduit.Core.DTOModels;
using Conduit.Core.Services;
using ConduitTests.Mocks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace ConduitTests.ServiceTests
{
    public class ArticleServiceTest
    {
        private readonly IArticleService articleService;
        public  ArticleServiceTest()
        {
            this.articleService = new ArticleService(RepositoryMocks.GetArticleRepository().Object, MapperMocks.GetMockMapper().Object);
        }
        [Fact]
        public async Task CreateArticleTest()
        {
            ArticleForInsertDTO articleForInsertDTO = new ArticleForInsertDTO { UserId = 1, ArticleTitle = "The Killing Joke 2", ArticleBody = "HAHAHAHAHA", date = DateTime.Now };
            ArticleDTO? articleDTO=await articleService.AddArticleAsync(articleForInsertDTO);
            Assert.NotNull(articleDTO);
        }
        [Fact]
        public async Task GetArticleTest()
        {
            ArticleDTO? articleDTO = await articleService.GetArticleAsync(1);
            Assert.NotNull(articleDTO);
        }
        [Fact]
        public async Task GetArticleNotFoundTest()
        {
            ArticleDTO? articleDTO = await articleService.GetArticleAsync(100);
            Assert.Null(articleDTO);
        }
        [Fact]
        public async Task GetUserArticlesTest()
        {
            IEnumerable<ArticleDTO?> articlesDTO = await articleService.GetUserArticlesAsync(1);
            Assert.True(articlesDTO.Any());
        }
        [Fact]
        public async Task UpdateArticleTest()
        {
            ArticleForUpdateDTO articleForUpdateDTO = new ArticleForUpdateDTO { ArticleTitle = "The Killing Joke 2", ArticleBody = "HAHAHAHAHA"};
            ArticleDTO? articleDTO = await articleService.UpdateArticleAsync(articleForUpdateDTO, 2);
            Assert.NotNull(articleDTO);
        }

    }
}
