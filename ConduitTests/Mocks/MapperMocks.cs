using AutoMapper;
using Conduit.Core.DTOModels;
using Conduit.Models;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConduitTests.Mocks
{
    public class MapperMocks
    {
        public static Mock<IMapper> GetMockMapper()
        {
            var mockMapper = new Mock<IMapper>();
            mockMapper.Setup(x => x.Map<UserForInsertDTO, User>(It.IsAny<UserForInsertDTO>()))
                 .Returns((UserForInsertDTO user) => new User { Username = user.Username, Password = user.Password, FullName = user.FullName });
            
            mockMapper.Setup(x => x.Map<User, UserDTO>(It.IsAny<User>()))
                .Returns((User user) => new UserDTO { UserId = user.UserId, Username = user.Username, Password = user.Password, FullName = user.FullName });
           
            mockMapper.Setup(x => x.Map<UserDTO, User>(It.IsAny<UserDTO>()))
                .Returns((UserDTO user) => new User { UserId = user.UserId, Username = user.Username, Password = user.Password, FullName = user.FullName });
           
            mockMapper.Setup(x => x.Map<UserForUpdateDTO, User>(It.IsAny<UserForUpdateDTO>()))
                .Returns((UserForUpdateDTO userUpdate)=>new User { Username=userUpdate.Username,Password=userUpdate.Password,FullName=userUpdate.FullName});
           
            mockMapper.Setup(x => x.Map<ArticleForInsertDTO, Article>(It.IsAny<ArticleForInsertDTO>()))
                .Returns((ArticleForInsertDTO article) => new Article { UserId = article.UserId, ArticleTitle = article.ArticleTitle, ArticleBody = article.ArticleBody, date = article.date });
            
            mockMapper.Setup(x => x.Map<ArticleForUpdateDTO, Article>(It.IsAny<ArticleForUpdateDTO>()))
                .Returns((ArticleForUpdateDTO article) => new Article { ArticleTitle = article.ArticleTitle, ArticleBody = article.ArticleBody});
           
            mockMapper.Setup(x => x.Map<ArticleDTO, Article>(It.IsAny<ArticleDTO>()))
                .Returns((ArticleDTO article) => new Article { ArticleId=article.ArticleId,UserId = article.UserId, ArticleTitle = article.ArticleTitle, ArticleBody = article.ArticleBody, date = article.date });
           
            mockMapper.Setup(x => x.Map<Article, ArticleDTO>(It.IsAny<Article>()))
                .Returns((Article article) => new ArticleDTO { ArticleId = article.ArticleId, UserId = article.UserId, ArticleTitle = article.ArticleTitle, ArticleBody = article.ArticleBody, date = article.date });

            mockMapper.Setup(x => x.Map<IEnumerable<Article>, IEnumerable<ArticleDTO>>(It.IsAny<IEnumerable<Article>>()))
                .Returns((IEnumerable<Article> articles) =>
                {
                    List<ArticleDTO> articlesDTO = new List<ArticleDTO>();
                    articles.ToList().ForEach(article => articlesDTO.Add(new ArticleDTO { ArticleId = article.ArticleId, UserId = article.UserId, ArticleTitle = article.ArticleTitle, ArticleBody = article.ArticleBody, date = article.date }));
                    return articlesDTO;
                }
            );
            return mockMapper;
        }
    }
}
