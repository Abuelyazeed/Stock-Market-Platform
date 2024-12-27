using FinPulse.BL.Managers.Portfolios;
using FinPulse.DAL;
using FinPulse.DAL.Repository.Portfolio;
using FinPulse.Extentions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace FinPulse.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class PortfolioController(UserManager<AppUser> userManager, IPortfolioManager portfolioManager) : ControllerBase
    {

        [HttpGet]
        public async Task<ActionResult> GetPortfolio()
        {
            var username = User.getUsername();
            var appUser = await userManager.FindByNameAsync(username);
            var userPortfolio = await portfolioManager.GetPorfolioAsync(appUser);
            
            return Ok(userPortfolio);
        }
    }
}
