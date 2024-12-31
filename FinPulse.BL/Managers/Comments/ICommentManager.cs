using FinPulse.DAL;

namespace FinPulse.BL;

public interface ICommentManager
{
    Task<List<CommentDto>> GetCommentsAsync(CommentParams commentParams);
    Task<CommentDto?> GetCommentAsync(int id);
    Task<CommentDto> CreateCommentAsync(int stockId, string userId,CommentCreateDto comment);
    Task<bool> DeleteCommentByIdAsync(int id);
    
    Task<CommentDto?> UpdateCommentAsync(int id, CommentUpdateDto comment);
}