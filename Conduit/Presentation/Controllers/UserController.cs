using Conduit.Core.DTOModels;
using Conduit.Core.Services;
using Conduit.Core.Validators;
using Conduit.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Conduit.Presentation.Controllers
{
    [ApiController]
    [Route("api/users")]
    [Authorize]
    public class UserController : Controller
    {
        private readonly IUserService userService;
        private readonly UserForInsertValidator userForInsertValidator;
        private readonly UserForUpdateValidator userForUpdateValidator;

        public UserController(IUserService userService, UserForInsertValidator userForInsertValidator, UserForUpdateValidator userForUpdateValidator)
        {
            this.userService = userService ?? throw new ArgumentNullException(nameof(userService));
            this.userForInsertValidator = userForInsertValidator ?? throw new ArgumentNullException(nameof(userForInsertValidator));
            this.userForUpdateValidator = userForUpdateValidator ?? throw new ArgumentNullException(nameof(userForUpdateValidator));
        }
        [HttpGet(Name = "GetUser")]
        [Route("{userId}")]
        public async Task<ActionResult<UserDTO?>> GetUser(int UserId)
        {
            UserDTO? userDTO = await userService.GetUserAsync(UserId);
            if (userDTO == null)
            {
                return NotFound("User Not Found");
            }
            return Ok(userDTO);
        }
        [HttpPost]
        public async Task<ActionResult<UserForInsertDTO>> PostUser(UserForInsertDTO userForInsertDTO)
        {
            if (userService.GetUserFromUserName(userForInsertDTO.Username).Result != null)
            {
                return BadRequest("400: Username is Taken");
            }
            var userForInsertValidationResult = userForInsertValidator.Validate(userForInsertDTO);
            if (userForInsertValidationResult.IsValid)
            {
                UserDTO? userDTO = await userService.AddUserAsync(userForInsertDTO);
                return CreatedAtRoute("GetUser", userDTO, userDTO);
            }
            else
            {
                string errors = "";
                userForInsertValidationResult.Errors.ToList().ForEach(error => errors += error.ToString() + " ,");
                return BadRequest("BadRequest 400: " + errors);
            }
        }
        [HttpPut]
        [Route("{userId}")]
        public async Task<ActionResult> PutUser(UserForUpdateDTO userForUpdateDTO,int UserId)
        {
            if(userService.GetUserFromUserName(userForUpdateDTO.Username).Result != null)
            {
                return BadRequest("400: Username is Taken");
            }
            var userForUpdateValidationResult=userForUpdateValidator.Validate(userForUpdateDTO);
            if(userForUpdateValidationResult.IsValid)
            {
                UserDTO? userDTO = await userService.GetUserAsync(UserId);
                if (userDTO == null)
                {
                    return NotFound("User Not Found");
                }
                else
                {
                   UserDTO? userReturnDTO= await userService.UpdateUserAsync(userForUpdateDTO, UserId);
                    return AcceptedAtRoute("GetUser",userReturnDTO,userReturnDTO);
                }
            }
            else
            {
                string errors = "";
                userForUpdateValidationResult.Errors.ToList().ForEach(error => errors += error.ToString() + " ,");
                return BadRequest("BadRequest 400: " + errors);
            }
        }
    }
}
