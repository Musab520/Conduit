using Conduit.Core.DTOModels;
using Conduit.Core.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Conduit.Presentation.Controllers
{
    [ApiController]
    [Route("api/favoriteArticles")]
    [Authorize]
    public class FavoriteArticlesController : Controller
    {
        private readonly IFavoriteArticleService favoriteArticleService;
        public FavoriteArticlesController(IFavoriteArticleService favoriteArticleService)
        {
            this.favoriteArticleService = favoriteArticleService ?? throw new ArgumentNullException(nameof(favoriteArticleService));
        }
        [HttpGet(Name = "GetFavoriteArticle")]
        [Route("{favoriteArticleId}")]
        public async Task<ActionResult<FavoriteArticlesDTO>> GetFavoriteArticle(int FavoriteArticleId)
        {
            FavoriteArticlesDTO? favoriteArticleDTO = await favoriteArticleService.GetFavoriteArticle(FavoriteArticleId); 
            if(favoriteArticleDTO == null)
            {
                return NotFound("Article Not Found");
            }
            return Ok(favoriteArticleDTO);  
        }
        [HttpPost]
        public async Task<ActionResult<FavoriteArticlesDTO>> PostFavoriteArticle(FavoriteArticlesForInsertDTO favoriteArticleForInsertDTO)
        {
          FavoriteArticlesDTO favoriteArticlesDTO =  await favoriteArticleService.AddFavoriteArticle(favoriteArticleForInsertDTO);
            return CreatedAtRoute("GetFavoriteArticle", favoriteArticlesDTO, favoriteArticlesDTO);
        }
        [HttpDelete]
        [Route("{favoriteArticleId}")]
        public async Task<ActionResult> DeleteFavoriteArticle(int FavoriteArticleId)
        {
            FavoriteArticlesDTO? favoriteArticleDTO = await favoriteArticleService.GetFavoriteArticle(FavoriteArticleId);
            if (favoriteArticleDTO == null)
            {
                return NotFound("Article Not Found");
            }
            await favoriteArticleService.DeleteFavoriteArticle(favoriteArticleDTO);
            return NoContent();
        }
        [HttpGet]
        [Route("users/{userId}")]
        public async Task<ActionResult<IEnumerable<FavoriteArticlesDTO>>> GetUserFavoriteArticles(int UserId)
        {
            IEnumerable<FavoriteArticlesDTO> favArticles=await favoriteArticleService.GetAllFavoriteArticles(UserId);
            return Ok(favArticles);
        }


    }
}
