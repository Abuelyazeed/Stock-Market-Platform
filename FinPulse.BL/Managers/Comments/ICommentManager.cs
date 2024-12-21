namespace FinPulse.BL;

public interface ICommentManager
{
    Task<List<CommentDto>> GetCommentsAsync();
    Task<CommentDto?> GetCommentAsync(int id);
    Task<int> CreateCommentAsync(int stockId, CommentCreateDto comment);
    Task DeleteCommentByIdAsync(int id);
    
    Task<CommentDto?> UpdateCommentAsync(int id, CommentUpdateDto comment);
}