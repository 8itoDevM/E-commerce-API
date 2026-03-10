using fakeshop.API.Models.DTO;
using fakeshop.API.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace fakeshop.API.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase {
        private readonly UserManager<IdentityUser> userManager;
        private readonly ITokenRepository tokenRepository;

        public AuthController(UserManager<IdentityUser> userManager, ITokenRepository tokenRepository) {
            this.userManager = userManager;
            this.tokenRepository = tokenRepository;
        }

        [HttpPost]
        [Route("Register")]
        public async Task<IActionResult> Register([FromBody] RegisterRequestDto registerRequest) {
            var identityUser = new IdentityUser {
                UserName = registerRequest.Username,
                Email = registerRequest.Email,
            };

            var identityResult = await userManager.CreateAsync(identityUser, registerRequest.Password);
            if(identityResult.Succeeded) {
                // Add roles to user
                if(registerRequest.Roles != null && registerRequest.Roles.Any()) {
                    identityResult = await userManager.AddToRolesAsync(identityUser, registerRequest.Roles);

                    if(identityResult.Succeeded) {
                        return Ok("User registered");
                    }
                }
            }

            return BadRequest("Couldn't create user");
        }

        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> Login([FromBody] LoginRequestDto loginRequest) {
            var user = await userManager.FindByEmailAsync(loginRequest.Email);
            
            if(user != null) {
                var checkPassword = await userManager.CheckPasswordAsync(user, loginRequest.Password);

                if(checkPassword) {
                    var roles = await userManager.GetRolesAsync(user);
                    
                    var jwtToken = tokenRepository.CreateJWTToken(user, roles.ToList());

                    var res = new LoginResponseDto {
                        JwtToken = jwtToken
                    };

                    return Ok(res);
                }
            }
            return BadRequest("Username or password incorrect");
        }
    }
}
