namespace FinPulse.BL;

public interface ICommentManager
{
    Task<List<CommentReadDto>> GetAllCommentsAsync();
    Task<CommentReadDto> GetCommentByIdAsync(int id);
    Task CreateCommentAsync(int stockId, CommentCreateDto comment);
    Task DeleteCommentByIdAsync(int id);
    
    Task<bool> UpdateCommentAsync(int id, CommentUpdateDto comment);
}