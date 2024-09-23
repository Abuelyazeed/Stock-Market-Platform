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
    }
}
