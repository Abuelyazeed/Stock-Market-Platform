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

        #region GetAll
        
        [HttpGet]
        public async Task<ActionResult<List<StockReadDto>>> GetAll()
        {
            List<StockReadDto> stocks = await _stockManager.GetAllStocksAsync();
            if (stocks == null || stocks.Count == 0) return NotFound("No stocks found.");
        
            return Ok(stocks);
        }
        
        #endregion
        
        #region GetById
        
        [HttpGet]
        [Route("{id:guid}")]
        public async Task<ActionResult<StockReadDto>> GetById(Guid id)
        {
            StockReadDto? stock = await _stockManager.GetStockByIdAsync(id);
            if(stock == null) return NotFound();
            
            return Ok(stock);
        }
        
        #endregion

        #region CreateStock
        [HttpPost]
        [Route("CreateStock")]
        public async Task<ActionResult> CreateStock(StockCreateDto stock)
        {
            await _stockManager.CreateStockAsync(stock);
            return Ok("Stock created successfully.");
        }

        #endregion

        #region UpdateStock

        [HttpPut]
        [Route("UpdateStock/{id:guid}")]
        public async Task<ActionResult> UpdateStock(StockUpdateDto stockUpdateDto,Guid id)
        {
            bool isSuccessful = await _stockManager.UpdateStockAsync(stockUpdateDto, id);
            if(!isSuccessful) return NotFound($"Stock with id {id} not found.");
            
            return Ok("Stock updated successfully.");
        }

        #endregion

        #region DeleteStock
        [HttpDelete]
        [Route("DeleteStock/{id:guid}")]
        public async Task<ActionResult> DeleteStock(Guid id)
        {
           bool isSuccessful =  await _stockManager.DeleteStockAsync(id);
           if(!isSuccessful) return NotFound($"Stock with id {id} not found.");
           
           return Ok("Stock deleted successfully.");
        }
        
        #endregion
    }
}
