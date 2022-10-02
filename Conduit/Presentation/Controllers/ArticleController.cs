using Conduit.Core.DTOModels;
using Conduit.Core.Services;
using Conduit.Core.Validators;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Conduit.Presentation.Controllers
{
    [ApiController]
    [Route("articles")]
    public class ArticleController : Controller
    {
        private readonly IArticleService articleService;
        private readonly ArticleForUpdateValidator articleForUpdateValidator;

        public ArticleController(IArticleService articleService, ArticleForUpdateValidator articleForUpdateValidator)
        {
            this.articleService = articleService ?? throw new ArgumentNullException(nameof(articleService));
            this.articleForUpdateValidator = articleForUpdateValidator ?? throw new ArgumentNullException(nameof(articleForUpdateValidator));
        }
        [HttpGet(Name = "GetArticle")]
        [Route("{articleId}")]
        public async Task<ActionResult<ArticleDTO?>> GetArticle(int ArticleId)
        {
            ArticleDTO? articleDTO = await articleService.GetArticleAsync(ArticleId);
            if (articleDTO == null)
            {
                return NotFound("Article Not Found");
            }
            return Ok(articleDTO);
        }
        [HttpPost]
        public async Task<ActionResult<ArticleDTO>> PostArticle(ArticleForInsertDTO articleForInsertDTO)
        {
            ArticleDTO? articleDTO = await articleService.AddArticleAsync(articleForInsertDTO);
            return CreatedAtRoute("GetArticle", articleDTO, articleDTO);
        }
        [HttpDelete]
        [Route("{articleId}")]
        public async Task<ActionResult> DeleteArticle(int ArticleId)
        {
            ArticleDTO? articleDTO = await articleService.GetArticleAsync(ArticleId);
            if (articleDTO == null)
            {
                return NotFound("Article Not Found");
            }
            await articleService.DeleteArticle(articleDTO);
            return NoContent();
        }
        [HttpPut]
        [Route("{articleId}")]
        public async Task<ActionResult> PutArticle(ArticleForUpdateDTO articleForUpdateDTO, int ArticleId)
        {
            var articleForUpdateValidationResult = articleForUpdateValidator.Validate(articleForUpdateDTO);
            if (articleForUpdateValidationResult.IsValid)
            {
                ArticleDTO? articleDTO = await articleService.GetArticleAsync(ArticleId);
                if (articleDTO == null)
                {
                    return NotFound("Article Not Found");
                }
                else
                {
                    await articleService.UpdateArticleAsync(articleForUpdateDTO, ArticleId);
                    return NoContent();
                }
            }
            else
            {
                string errors = "";
                articleForUpdateValidationResult.Errors.ToList().ForEach(error => errors += error.ToString() + " ,");
                return BadRequest("BadRequest 400: " + errors);
            }
        }
        [HttpGet]
        [Route("users/{userId}")]
        public async Task<ActionResult<IEnumerable<ArticleDTO>>> GetUserArticles(int UserId)
            {
            IEnumerable<ArticleDTO> articles= await articleService.GetUserArticlesAsync(UserId);   
            return Ok(articles);    
            }



    }
}
