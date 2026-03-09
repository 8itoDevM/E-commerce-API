using fakeshop.API.Models.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace fakeshop.API.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase {
        private readonly UserManager<IdentityUser> userManager;

        public AuthController(UserManager<IdentityUser> userManager) {
            this.userManager = userManager;
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
    }
}
