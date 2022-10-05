using Conduit.Core.DTOModels;
using Conduit.Core.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Conduit.Presentation.Controllers
{
   
    [ApiController]
    [Route("api")]
    [Authorize]
    public class UserFollowerController : Controller
    {
        private readonly IUserFollowersService followersService;
        public UserFollowerController(IUserFollowersService followersService)
        {
            this.followersService = followersService ?? throw new ArgumentNullException(nameof(followersService));
        }
        [HttpGet]
       [Route("users/{userId}/followers")]
       public async Task<ActionResult<IEnumerable<FollowerDTO>>> GetUserFollowers(int UserId)
        {
            IEnumerable<FollowerDTO?> followers = await followersService.GetAllUserFollowers(UserId);
            return Ok(followers); 
        }
        [HttpPost]
        [Route("followers")]
        public async Task<ActionResult<FollowerDTO>> AddFollower(FollowersForInsertDTO followerForInsertDTO)
        {
            FollowerDTO? followerDTO = await followersService.AddFollower(followerForInsertDTO);
            return CreatedAtRoute("GetFollower",followerDTO,followerDTO);
        }
        [HttpGet(Name ="GetFollower")]
        [Route("followers/{userfollowerId}")]
        public async Task<ActionResult<FollowerDTO>> GetFollower(int UserFollowerId)
        {
            FollowerDTO? followerDTO= await followersService.GetFollower(UserFollowerId);
            if(followerDTO == null)
            {
                return NotFound("Follower Not found");
            }
            return Ok(followerDTO);
        }
        [HttpDelete]
        [Route("followers/{userfollowerId}")]
        public async Task<ActionResult> DeleteFollower(int UserFollowerId)
        {
            FollowerDTO? followerDTO = await followersService.GetFollower(UserFollowerId);
            if (followerDTO == null)
            {
                return NotFound("Follower Not found");
            }
            await followersService.DeleteUserFollowers(followerDTO);
            return NoContent();
        }

    }
}
