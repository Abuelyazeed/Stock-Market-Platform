using FinPulse.BL;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FinPulse.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class PortfolioController(IPortfolioManager portfolioManager, IStockManager stockManager) : ControllerBase
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
            
            //get stock
            var stock = await stockManager.GetStockBySymbolAsync(symbol);
            
            //stock does not exist so get it from external api
            if (stock == null)
            {
                stock = await stockManager.EnsureStockExistsAsync(symbol);
                if (stock == null)
                {
                    return BadRequest("Stock does not exist.");
                }
            }
             
            //Get user portfolio to check if stock already exists there
            var userPortfolio = await portfolioManager.GetPortfolioAsync(userId);

            if (userPortfolio.Any(x => x.Symbol.ToLower() == symbol.ToLower()))
            {
                return BadRequest("Stock already exists");
            }

            var portfolio = await portfolioManager.AddStockToPortfolioAsync(stock.Id, userId);
            
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
