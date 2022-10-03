using Conduit.Core.DTOModels;
using Conduit.Core.Services;
using Conduit.Core.Validators;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Conduit.Presentation.Controllers
{
    [ApiController]
    [Route("api/comments")]
    [Authorize]
    public class CommentController : Controller
    {
        private readonly ICommentService commentService;
        private readonly CommentForInsertValidator commentForInsertValidator;

        public CommentController(ICommentService commentService, CommentForInsertValidator commentForInsertValidator)
        {
            this.commentService = commentService ?? throw new ArgumentNullException(nameof(commentService));
            this.commentForInsertValidator = commentForInsertValidator ?? throw new ArgumentNullException(nameof(commentForInsertValidator));
        }
        [HttpGet(Name ="GetComment")]
        [Route("{commentId}")]
        public async Task<ActionResult<CommentDTO>> GetComment(int CommentId)
        {
           CommentDTO? comment= await commentService.GetComment(CommentId);
            if (comment == null)
                return NotFound("Comment Not Found");
            return Ok(comment);
        }
        [HttpPost]
        public async Task<ActionResult<CommentForInsertDTO>> PostComment(CommentForInsertDTO commentForInsert)
        {
           var commentForInsertValidationResult = commentForInsertValidator.Validate(commentForInsert);
            if (commentForInsertValidationResult.IsValid)
            {
                CommentDTO commentDTO=await commentService.AddComment(commentForInsert);
                return CreatedAtRoute("GetComment",commentDTO,commentDTO);
            }
            else
            {
                string errors = "";
                commentForInsertValidationResult.Errors.ToList().ForEach(error => errors += error.ToString() + " ,");
                return BadRequest("BadRequest 400: " + errors);
            }
        } 
        [HttpDelete]
        [Route("{commentId}")]
        public async Task<ActionResult> DeleteComment(int CommentId)
        {
            CommentDTO? commentDTO=await commentService.GetComment(CommentId);
            if(commentDTO == null)
            {
                return NotFound("Comment Not Found");
            }
            await commentService.DeleteComment(commentDTO);
            return NoContent();
        }
        [HttpGet]
        [Route("users/{userId}")]
        public async Task<ActionResult<IEnumerable<CommentDTO>>> GetUserComments(int UserId)
        {
            IEnumerable<CommentDTO> comments= await commentService.GetUserComments(UserId); 
            return Ok(comments);    
        }
        [HttpGet]
        [Route("articles/{articleId}")]
        public async Task<ActionResult<IEnumerable<CommentDTO>>> GetArticleComments(int articleId)
        {
            IEnumerable<CommentDTO> comments = await commentService.GetArticleComments(articleId);
            return Ok(comments);    
        }
    }
}
