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
            var userId = User.getUserId();
            var userPortfolio = await portfolioManager.GetPorfolioAsync(userId);
            
            return Ok(userPortfolio);
        }
    }
}
