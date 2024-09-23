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
        [Route("{id}")]
        public async Task<ActionResult> GetById(Guid id)
        {
            CommentReadDto comment = await _commentManager.GetCommentByIdAsync(id);
            if(comment == null) return NotFound("No comment found.");
            
            return Ok(comment);
        }

        #endregion
        
        #region CreateComment

        [HttpPost]
        [Route("CreateComment/{stockId}")]
        public async Task<ActionResult> CreateComment(Guid stockId,CommentCreateDto comment)
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
        [Route("UpdateComment/{id}")]
        public async Task<ActionResult> UpdateComment(Guid id, CommentUpdateDto comment)
        {
            bool isSuccessful = await _commentManager.UpdateCommentAsync(id, comment);
            if(!isSuccessful) return BadRequest("Failed to update comment.");
            
            return Ok("Comment updated successfully.");
        }
        #endregion
        
        #region DeleteComment

        [HttpDelete]
        [Route("DeleteComment/{id}")]
        public async Task<ActionResult> DeleteComment(Guid id)
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
