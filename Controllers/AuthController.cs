using Dotnet_v8.Models.DTOs;
using Dotnet_v8.Repository;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Dotnet_v8.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController(UserManager<IdentityUser> userManager,ITokenRepository tokenRepository) : ControllerBase
    {
        private readonly UserManager<IdentityUser> UserManager = userManager;
        private readonly ITokenRepository TokenRepository = tokenRepository;
        [HttpPost]
        [Route("Register")]
        public async Task<IActionResult> Register([FromBody] RegisterRequestDto register)
        {
            var identityUser = new IdentityUser
            {
                UserName = register.UserName,
                Email = register.UserName
            };

            var identityResult = await UserManager.CreateAsync(identityUser, register.Password);
            if (identityResult.Succeeded)
            {
                if (register.Roles != null && register.Roles.Any())
                {
                    identityResult = await UserManager.AddToRolesAsync(identityUser, register.Roles);
                    if (identityResult.Succeeded)
                    {
                        return Ok("User was registered Successfully");
                    }
                }
            }
            return BadRequest("SomeThing went wrong");
        }

        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> Login([FromBody] LoginRequestDto login)
        {
            var user = await UserManager.FindByEmailAsync(login.UserName);
            if (user != null)
            {
                var checkPassword = await UserManager.CheckPasswordAsync(user, login.Password);
                if(checkPassword)
                {
                    var roles = await UserManager.GetRolesAsync(user);
                    if(roles != null)
                    {
                        var jwtToken = TokenRepository.CreateJWTToken(user, roles.ToList());

                        var token = new LoginResponseDto
                        {
                            JwtToken = jwtToken
                        };

                        return Ok(token);
                    }
                }
            }
            return BadRequest("Something went wrong");
        }
    }
}
