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
        public static Mock<ICommentRepository> GetCommentRepository()
        {
            var comments = new List<Comment>
            {
                new Comment{CommentId=1,ArticleId=1,UserId=1,BodyText="WOO",date=DateTime.Now},
                new Comment{CommentId=2,ArticleId=1,UserId=2,BodyText="WOO",date=DateTime.Now},
                new Comment{CommentId=3,ArticleId=2,UserId=2,BodyText="WOO",date=DateTime.Now},
                new Comment{CommentId=4,ArticleId=2,UserId=3,BodyText="WOO",date=DateTime.Now},
                new Comment{CommentId=5,ArticleId=3,UserId=3,BodyText="WOO",date=DateTime.Now},
                new Comment{CommentId=6,ArticleId=3,UserId=4,BodyText="WOO",date=DateTime.Now},
                new Comment{CommentId=7,ArticleId=4,UserId=4,BodyText="WOO",date=DateTime.Now},
                new Comment{CommentId=8,ArticleId=4,UserId=5,BodyText="WOO",date=DateTime.Now},
                new Comment{CommentId=9,ArticleId=5,UserId=5,BodyText="WOO",date=DateTime.Now},
                new Comment{CommentId=10,ArticleId=5,UserId=6,BodyText="WOO",date=DateTime.Now}
            };
            var mockCommentRepository =new Mock<ICommentRepository>();
            mockCommentRepository.Setup(x => x.AddComment(It.IsAny<Comment>()));
            mockCommentRepository.Setup(x => x.GetComment(It.IsAny<int>())).Returns((int i) => Task.FromResult(comments.FirstOrDefault(comment => comment.CommentId == i)));
            mockCommentRepository.Setup(x => x.DeleteComment(It.IsAny<Comment>()));
            mockCommentRepository.Setup(x => x.GetUserComments(It.IsAny<int>())).Returns((int i) => Task.FromResult(comments.Where(comment => comment.UserId == i)));
            mockCommentRepository.Setup(x => x.GetArticleComments(It.IsAny<int>())).Returns((int i) => Task.FromResult(comments.Where(comment => comment.ArticleId == i)));
            return mockCommentRepository;
        }
        public static Mock<IFavoriteArticlesRepository> GetFavoriteArticlesRepository()
        {
            var favorites = new List<FavoriteArticles>
            {
                new FavoriteArticles { FavoriteArticlesId = 1,ArticleId=1,UserId=1 },
                new FavoriteArticles { FavoriteArticlesId = 2,ArticleId=2,UserId=1 },
                new FavoriteArticles { FavoriteArticlesId = 3,ArticleId=3,UserId=1 },
                new FavoriteArticles { FavoriteArticlesId = 4,ArticleId=4,UserId=2 },
                new FavoriteArticles { FavoriteArticlesId = 5,ArticleId=5,UserId=2 },
                new FavoriteArticles { FavoriteArticlesId = 6,ArticleId=6,UserId=2 },
                new FavoriteArticles { FavoriteArticlesId = 7,ArticleId=1,UserId=3 },
                new FavoriteArticles { FavoriteArticlesId = 8,ArticleId=2,UserId=3 },
                new FavoriteArticles { FavoriteArticlesId = 9,ArticleId=3,UserId=3 },
                new FavoriteArticles { FavoriteArticlesId = 10,ArticleId=4,UserId=4 },
                new FavoriteArticles { FavoriteArticlesId = 11,ArticleId=5,UserId=4 },
            };
            var mockFavoriteArticlesRepository = new Mock<IFavoriteArticlesRepository>();
            mockFavoriteArticlesRepository.Setup(x => x.AddFavoriteArticle(It.IsAny<FavoriteArticles>()));
            mockFavoriteArticlesRepository.Setup(x => x.GetFavoriteArticle(It.IsAny<int>())).Returns((int i) => Task.FromResult(favorites.FirstOrDefault(favorite => favorite.FavoriteArticlesId == i)));
            mockFavoriteArticlesRepository.Setup(x => x.DeleteFavoriteArticle(It.IsAny<FavoriteArticles>()));
            mockFavoriteArticlesRepository.Setup(x => x.GetAllFavoriteArticles(It.IsAny<int>())).Returns((int i)=>Task.FromResult(favorites.Where(favorite=>favorite.UserId==i)));
            return mockFavoriteArticlesRepository;
        }
        public static Mock<IFollowRepository> GetUserFollowersRepository()
        {
            var followers = new List<UserFollowers>
            {
                new UserFollowers{UserFollowersId = 1,UserId=1,FollowerId=1},
                new UserFollowers{UserFollowersId = 2,UserId=1,FollowerId=2},
                new UserFollowers{UserFollowersId = 3,UserId=1,FollowerId=3},
                new UserFollowers{UserFollowersId = 4,UserId=2,FollowerId=4},
                new UserFollowers{UserFollowersId = 5,UserId=2,FollowerId=5},
                new UserFollowers{UserFollowersId = 6,UserId=2,FollowerId=6},
                new UserFollowers{UserFollowersId = 7,UserId=3,FollowerId=7},
                new UserFollowers{UserFollowersId = 8,UserId=3,FollowerId=8},
                new UserFollowers{UserFollowersId = 9,UserId=3,FollowerId=9},
                new UserFollowers{UserFollowersId = 10,UserId=4,FollowerId=1}
            };
            var mockUserFollowersRepository = new Mock<IFollowRepository>();
            mockUserFollowersRepository.Setup(x => x.AddFollower(It.IsAny<UserFollowers>()));
            mockUserFollowersRepository.Setup(x => x.GetFollower(It.IsAny<int>())).Returns((int i) => Task.FromResult(followers.FirstOrDefault(follower => follower.UserFollowersId== i)));
            mockUserFollowersRepository.Setup(x => x.DeleteUserFollowers(It.IsAny<UserFollowers>()));
            mockUserFollowersRepository.Setup(x => x.GetAllUserFollowers(It.IsAny<int>())).Returns((int i) => Task.FromResult(followers.Where(follower => follower.UserId == i)));
            return mockUserFollowersRepository;
        }
    }
}
