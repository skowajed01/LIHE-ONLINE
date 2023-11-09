using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using LIHE.Models;

namespace LIHE.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    public class AccountController : ControllerBase
    {
        private readonly UserManager<IdentityUser> userManager;
        private readonly SignInManager<IdentityUser> signInManager;

        public AccountController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
        }

        [HttpPost]
        [Route("Registration")]
        public async Task<IActionResult> Register([FromBody] Registration registrationRequest)
        {
            var user = new IdentityUser()
            {
                Email = registrationRequest.UserName,
                UserName = registrationRequest.UserName,
            };
            var result = await userManager.CreateAsync(user, registrationRequest.Password);

            if (result.Succeeded)
            {
                return Ok("User Created Successfully! please Login");
            }

            return BadRequest();

        }
    }
}
