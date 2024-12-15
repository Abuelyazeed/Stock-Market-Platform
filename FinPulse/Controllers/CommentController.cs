using FinPulse.BL;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FinPulse.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentController : ControllerBase
    {
        private readonly ICommentManager _commentManager;
        public CommentController(ICommentManager commentManager)
        {
            _commentManager = commentManager;
        }

        #region GetAll

        [HttpGet]
        public async Task<ActionResult> GetAll()
        {
            List<CommentReadDto> comments = await _commentManager.GetAllCommentsAsync();
            if(comments == null || comments.Count == 0) return NotFound("No comments found.");
            
            return Ok(comments);
        }

        #endregion
        
        #region GetById

        [HttpGet]
        [Route("{id:int}")]
        public async Task<ActionResult> GetById(int id)
        {
            CommentReadDto comment = await _commentManager.GetCommentByIdAsync(id);
            if(comment == null) return NotFound("No comment found.");
            
            return Ok(comment);
        }

        #endregion
        
        #region CreateComment

        [HttpPost]
        [Route("CreateComment/{stockId:int}")]
        public async Task<ActionResult> CreateComment(int stockId,CommentCreateDto comment)
        {
            try
            {
                await _commentManager.CreateCommentAsync(stockId, comment);
                return Ok("Comment created successfully.");
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        #endregion

        #region UpdateComment

        [HttpPut]
        [Route("UpdateComment/{id:int}")]
        public async Task<ActionResult> UpdateComment(int id, CommentUpdateDto comment)
        {
            bool isSuccessful = await _commentManager.UpdateCommentAsync(id, comment);
            if(!isSuccessful) return BadRequest("Failed to update comment.");
            
            return Ok("Comment updated successfully.");
        }
        #endregion
        
        #region DeleteComment

        [HttpDelete]
        [Route("DeleteComment/{id:int}")]
        public async Task<ActionResult> DeleteComment(int id)
        {
            try
            {
                await _commentManager.DeleteCommentByIdAsync(id);
                return Ok("Comment deleted successfully.");
            }
            catch (Exception ex)
            {
                return NotFound("Can not delete comment.");
            }
        }
        #endregion
    }
}
