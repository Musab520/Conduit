using Conduit.Core.DTOModels;
using Conduit.Core.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Conduit.Presentation.Controllers
{
    [ApiController]
    [Route("api/authentication")]
    public class AuthenticationController : Controller
    {
        private readonly IConfiguration _configuration;
        private readonly IUserService userService;

        public AuthenticationController(IConfiguration configuration,IUserService userService)
        {
            _configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
            this.userService = userService ?? throw new ArgumentNullException(nameof(userService));
        }
        public class AuthenticationRequestBody
        {
            public string? Username { get; set; }
            public string? Password { get; set; }   
        }
        [HttpPost("authenticate")]
        public async Task<ActionResult<string>> Authenticate(AuthenticationRequestBody authenticationRequestBody)
        {
            var user = await ValidateUserCredentials(authenticationRequestBody.Username, authenticationRequestBody.Password);
            if(user == null)
            {
                return Unauthorized("User Not Found");
            }
            var securityKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_configuration["Authentication:SecretForKey"]));
            var signingCredential=new SigningCredentials(securityKey,SecurityAlgorithms.HmacSha256);
            var claimsForToken = new List<Claim>();
            claimsForToken.Add(new Claim("sub", user.UserId.ToString()));
            if(user.FullName != null)
            claimsForToken.Add(new Claim("Full_Name", user.FullName.ToString()));
            var jwtSecurityToken = new JwtSecurityToken(_configuration["Authentication:Issuer"], _configuration["Authentication:Audience"], claimsForToken, DateTime.UtcNow, DateTime.UtcNow.AddHours(1), signingCredential);
            var tokentoReturn = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken);
            return Ok(tokentoReturn);

        }

        private async Task<UserDTO> ValidateUserCredentials(string? username, string? password)
        {
                UserDTO? userDTO = await userService.GetUserFromUserName(username);
                if (userDTO == null)
                {
                   return null;
                }
                if (userDTO.Password.Equals(password))
                {
                    return userDTO;
                }
                else
                {
                    return null;
                }
            
            
            
            
            
        }
    }
}
