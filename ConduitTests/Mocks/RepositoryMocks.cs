using Conduit.Infrastructure.Repositories;
using Conduit.Models;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConduitTests.Mocks
{
    public class RepositoryMocks
    {
        public static Mock<IUserRepository> GetUserRepository()
        {
            var users = new List<User>
            {
                new User { UserId=1,Username="Admin",Password="Admin123",FullName="Admin"},
                new User { UserId=2,Username="musab",Password="musab123",FullName="Musab Abuasi"},
                new User { UserId=3,Username="yahya",Password="yahya123",FullName="Yahya Abuasi"},
                new User { UserId=4,Username="bob",Password="bob123",FullName="Bob The Builder"},
                new User { UserId=5,Username="tarek",Password="tarek123",FullName="Tarek Kirresh"},
                new User { UserId=6,Username="mazen",Password="mazen123",FullName="Mazen Amria"}
            };
            var mockUserRepository = new Mock<IUserRepository>();
            Random random=new Random(100);
            mockUserRepository.Setup(x => x.AddUser(It.IsAny<User>())).Returns(Task.CompletedTask);
            mockUserRepository.Setup(x => x.GetUser(It.IsAny<int>())).Returns((int i)=>Task.FromResult(users.FirstOrDefault(user=>user.UserId==i)));
            mockUserRepository.Setup(x => x.GetUserFromUsername(It.IsAny<string>())).Returns((string s) => Task.FromResult(users.FirstOrDefault(user => user.Username == s)));
            return mockUserRepository;
        }
        public static Mock<IArticleRepository> GetArticleRepository()
        {
            var articles = new List<Article>
            {
                new Article {ArticleId=1,UserId=1,ArticleTitle="The Killing Joke",ArticleBody="HAHAHAHAHA",date=DateTime.Now},
                 new Article {ArticleId=2,UserId=1,ArticleTitle="Oogli Boogli",ArticleBody="blahblah",date=DateTime.Now},
                  new Article {ArticleId=3,UserId=2,ArticleTitle="Murder Mystery",ArticleBody="dfgc hjk",date=DateTime.Now},
                   new Article {ArticleId=4,UserId=2,ArticleTitle="Control",ArticleBody="wertyukjhgfd",date=DateTime.Now},
                    new Article {ArticleId=5,UserId=3,ArticleTitle="No Road left except the one that leads to the end",ArticleBody="oofofofofo",date=DateTime.Now},
                     new Article {ArticleId=6,UserId=3,ArticleTitle="Shark Tank",ArticleBody="Royalties Royalties",date=DateTime.Now},
            };
            var mockArticleRepository = new Mock<IArticleRepository>();
            mockArticleRepository.Setup(x => x.AddArticle(It.IsAny<Article>()));
            mockArticleRepository.Setup(x => x.GetArticle(It.IsAny<int>())).Returns((int i)=>Task.FromResult(articles.FirstOrDefault(article=>article.ArticleId==i)));
            mockArticleRepository.Setup(x => x.DeleteArticle(It.IsAny<Article>()));
            mockArticleRepository.Setup(x => x.GetUserArticles(It.IsAny<int>())).Returns((int i)=>Task.FromResult(articles.Where(article=>article.UserId==i)));
            return mockArticleRepository;

        }
        //public static Mock<ICommentRepository> GetCommentRepository()
        //{

        //}
        //public static Mock<IFavoriteArticlesRepository> GetFavoriteArticlesRepository()
        //{

        //}
        //public static Mock<IFollowRepository> GetUserFollowersRepository()
        //{

        //}
    }
}
