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
    public class ArticleRepositoryTests
    {
        Mock<IArticleRepository> articleRepository = RepositoryMocks.GetArticleRepository();
        [Fact]
        public async void GetArticleTest()
        {
            Article? article = await articleRepository.Object.GetArticle(5);
            Assert.NotNull(article);
        }
        [Fact]
        public async void GetArticleNotFoundTest()
        {
            Article? article = await articleRepository.Object.GetArticle(70);
            Assert.Null(article);
        }
        [Fact]
        public async void AddArticleTest()
        {
            Random random = new Random();
            int rand = random.Next(100);
            Article a = new Article { ArticleId = rand, ArticleTitle = "dummy" + rand, ArticleBody = "dummy123" };
            await articleRepository.Object.AddArticle(a);
            articleRepository.Verify(x => x.AddArticle(a));
        }
        [Fact]
        public async void DeleteArticleTest()
        {
            Random random = new Random();
            int rand = random.Next(100);
            Article a = new Article { ArticleId = 1, ArticleTitle = "dummy" + rand, ArticleBody = "dummy123" };
            articleRepository.Object.DeleteArticle(a);
            articleRepository.Verify(x => x.DeleteArticle(a));
        }
        [Fact]
        public async void GetUserArticlesTest()
        {
            IEnumerable<Article?> articles = await articleRepository.Object.GetUserArticles(1);
            Assert.NotNull(articles);
            Assert.True(articles.Any());
        }
    }
}
