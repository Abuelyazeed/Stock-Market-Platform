using FinPulse.BL;
using FinPulse.DAL;
using Microsoft.AspNetCore.Http;
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
        public ActionResult<List<StockReadDto>> GetAll()
        {
            List<StockReadDto> stocks = _stockManager.GetAllStocks();
            if (stocks == null) return NotFound();
        
            return Ok(stocks);
        }
        
        #endregion
        
        #region GetById
        
        [HttpGet]
        [Route("{id}")]
        public ActionResult<StockReadDto> GetById(Guid id)
        {
            StockReadDto? stock = _stockManager.GetStockById(id);
            if(stock == null) return NotFound();
            
            return Ok(stock);
        }
        
        #endregion

        #region CreateStock
        [HttpPost]
        [Route("CreateStock")]
        public ActionResult CreateStock(StockCreateDto stock)
        {
            _stockManager.CreateStock(stock);
            return Ok();
        }

        #endregion

        #region UpdateStock

        [HttpPut]
        [Route("UpdateStock/{id}")]
        public ActionResult UpdateStock(StockUpdateDto stockUpdateDto,Guid id)
        {
            bool isSuccessful = _stockManager.UpdateStock(stockUpdateDto, id);
            if(!isSuccessful) return NotFound();
            
            return Ok();
        }

        #endregion
    }
}
