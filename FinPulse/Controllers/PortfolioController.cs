using FinPulse.BL;
using FinPulse.DAL;
using FinPulse.Extentions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace FinPulse.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class PortfolioController(IPortfolioManager portfolioManager, IStockRepo stockRepo) : ControllerBase
    {

        [HttpGet]
        public async Task<ActionResult> GetPortfolio()
        {
            var userId = User.getUserId();
            var userPortfolio = await portfolioManager.GetPortfolioAsync(userId);
            
            return Ok(userPortfolio);
        }

        [HttpPost("{symbol}")]
        public async Task<ActionResult> AddStockToPortfolio(string symbol)
        {
            var userId = User.getUserId();
            var stock = await stockRepo.GetStockBySymbol(symbol);
            
            if(stock == null) return BadRequest("Stock not found");
            
            //Get user portfolio to check if stock already exists there
            var userPortfolio = await portfolioManager.GetPortfolioAsync(userId);

            if (userPortfolio.Any(x => x.Symbol.ToLower() == symbol.ToLower()))
            {
                return BadRequest("Stock already exists");
            }

            var addPortfolio = new Portfolio
            {
                StockId = stock.Id,
                AppUserId = userId
            };

            var portfolio = await portfolioManager.AddStockToPortfolioAsync(addPortfolio);
            
            return Created();

        }

        [HttpDelete("{symbol}")]
        public async Task<ActionResult> RemoveStockFromPortfolio(string symbol)
        {
            var userId = User.getUserId();

            bool isSuccessful = await portfolioManager.RemoveStockFromPortfolioAsync(userId, symbol);
            if(!isSuccessful) return NotFound("Failed to remove stock");
            
            return NoContent();
        }
    }
}
