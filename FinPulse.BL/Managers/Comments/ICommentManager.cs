using FinPulse.DAL;

namespace FinPulse.BL;

public interface ICommentManager
{
    Task<List<CommentDto>> GetCommentsAsync();
    Task<CommentDto?> GetCommentAsync(int id);
    Task<CommentDto> CreateCommentAsync(int stockId, CommentCreateDto comment, string userId);
    Task<bool> DeleteCommentByIdAsync(int id);
    
    Task<CommentDto?> UpdateCommentAsync(int id, CommentUpdateDto comment);
}