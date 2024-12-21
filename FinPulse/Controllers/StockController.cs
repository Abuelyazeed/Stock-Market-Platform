using FinPulse.BL;
using Microsoft.AspNetCore.Mvc;

namespace FinPulse.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StockController : ControllerBase
    {
        private readonly IStockManager _stockManager;
        public StockController(IStockManager stockManager)
        {
            _stockManager = stockManager;
        }

        #region GetStocks
        
        [HttpGet]
        public async Task<ActionResult<List<StockDto>>> GetStocks()
        {
            var stocks = await _stockManager.GetStocksAsync();
            // if (stocks == null || stocks.Count == 0) return NotFound("No stocks found.");
        
            return Ok(stocks);
        }
        
        #endregion
        
        #region GetStock
        
        [HttpGet]
        [Route("{id:int}")]
        public async Task<ActionResult<StockDto>> GetStock(int id)
        {
            var stock = await _stockManager.GetStockAsync(id);
            if(stock == null) return NotFound();
            
            return stock;
        }
        
        #endregion

        #region CreateStock
        [HttpPost]
        public async Task<ActionResult> CreateStock(StockCreateDto stock)
        {
            int stockId = await _stockManager.CreateStockAsync(stock);
            var createdStock = await _stockManager.GetStockAsync(stockId);
            return CreatedAtAction(nameof(GetStock), new { id = stockId }, createdStock);
        }

        #endregion

        #region UpdateStock

        [HttpPut]
        [Route("{id:int}")]
        public async Task<ActionResult> UpdateStock(StockUpdateDto stockUpdateDto,int id)
        {
            var stock = await _stockManager.UpdateStockAsync(stockUpdateDto, id);
            if(stock == null) return NotFound("Stock not found.");
            
            return Ok(stock);
        }

        #endregion

        #region DeleteStock
        [HttpDelete]
        [Route("{id:int}")]
        public async Task<ActionResult> DeleteStock(int id)
        {
           bool isSuccessful =  await _stockManager.DeleteStockAsync(id);
           if(!isSuccessful) return NotFound("Stock not found.");
           
           return NoContent();
        }
        
        #endregion
    }
}
