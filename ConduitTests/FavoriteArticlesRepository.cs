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
    public class FavoriteArticlesRepository
    {
        Mock<IFavoriteArticlesRepository> articleRepository = RepositoryMocks.GetFavoriteArticlesRepository();
        [Fact]
        public async void GetFavoriteArticle()
        {
            FavoriteArticles? article = await articleRepository.Object.GetFavoriteArticle(5);
            Assert.NotNull(article);
        }
        [Fact]
        public async void GetFavoriteArticleNotFound()
        {
            FavoriteArticles? article = await articleRepository.Object.GetFavoriteArticle(50);
            Assert.Null(article);
        }
        [Fact]
        public async void AddFavoriteArticleTest()
        {
            Random random = new Random();
            int rand = random.Next(100);
            FavoriteArticles a = new FavoriteArticles { FavoriteArticlesId = rand, ArticleId = 5, UserId = 1 };
            await articleRepository.Object.AddFavoriteArticle(a);
            articleRepository.Verify(x => x.AddFavoriteArticle(a));
        }
        [Fact]
        public async void DeleteFavoriteArticleTest()
        {
            Random random = new Random();
            int rand = random.Next(100);
            FavoriteArticles a = new FavoriteArticles { FavoriteArticlesId = 1 };
            articleRepository.Object.DeleteFavoriteArticle(a);
            articleRepository.Verify(x => x.DeleteFavoriteArticle(a));
        }
        [Fact]
        public async void GetFavoriteArticlesTest()
        {
            IEnumerable<FavoriteArticles?> articles = await articleRepository.Object.GetAllFavoriteArticles(1);
            Assert.NotNull(articles);
            Assert.True(articles.Any());
        }
    }
}
