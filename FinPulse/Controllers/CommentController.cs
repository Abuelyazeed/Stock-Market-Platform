using FinPulse.BL;
using FinPulse.DAL;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace FinPulse.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class CommentController(UserManager<AppUser> userManager, ICommentManager commentManager, IStockManager stockManager) : ControllerBase
    {
        #region GetComments

        [HttpGet]
        public async Task<ActionResult> GetComments()
        {
            var comments = await commentManager.GetCommentsAsync();
            
            return Ok(comments);
        }

        #endregion
        
        #region GetComment

        [HttpGet]
        [Route("{id:int}")]
        public async Task<ActionResult> GetComment(int id)
        {
            CommentDto? comment = await commentManager.GetCommentAsync(id);
            if(comment == null) return NotFound("Comment not found.");
            
            return Ok(comment);
        }

        #endregion
        
        #region CreateComment

        [HttpPost]
        [Route("{symbol}")]
        public async Task<ActionResult> CreateComment(string symbol,CommentCreateDto comment)
        {
            //get user
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
            
            
            var createdComment = await commentManager.CreateCommentAsync(stock.Id, userId, comment);
            return CreatedAtAction(nameof(GetComment), new { id = createdComment.Id }, createdComment);
        }

        #endregion

        #region UpdateComment

        [HttpPut]
        [Route("{id:int}")]
        public async Task<ActionResult> UpdateComment(int id, CommentUpdateDto commentToUpdate)
        {
            var comment = await commentManager.UpdateCommentAsync(id, commentToUpdate);
            if(comment == null) return BadRequest("Comment not found.");
            
            return Ok(comment);
        }
        #endregion
        
        #region DeleteComment

        [HttpDelete]
        [Route("{id:int}")]
        public async Task<ActionResult> DeleteComment(int id)
        {
            bool isSuccessful = await commentManager.DeleteCommentByIdAsync(id);
            if(!isSuccessful) return NotFound("Comment not found.");
           
            return NoContent();
        }
        #endregion
    }
}
