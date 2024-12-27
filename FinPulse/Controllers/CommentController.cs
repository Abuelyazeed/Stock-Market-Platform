using FinPulse.BL;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FinPulse.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class CommentController(ICommentManager commentManager, IStockManager stockManager) : ControllerBase
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
        [Route("{stockId:int}")]
        public async Task<ActionResult> CreateComment(int stockId,CommentCreateDto comment)
        {
            var stock = await stockManager.GetStockAsync(stockId);
            if (stock == null)
            {
                return NotFound("Stock does not exist");
            }
            var commentId = await commentManager.CreateCommentAsync(stockId, comment);
            var createdComment = await commentManager.GetCommentAsync(commentId);
            return CreatedAtAction(nameof(GetComment), new { id = commentId }, createdComment);
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
