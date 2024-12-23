using FinPulse.BL;
using FinPulse.DAL;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace FinPulse.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController(UserManager<AppUser> userManager) : ControllerBase
    {
        [HttpPost]
        public async Task<ActionResult> Register(RegisterDto registerDto)
        {
            
        }
    }
}
