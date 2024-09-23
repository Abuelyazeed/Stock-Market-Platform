namespace FinPulse.BL;

public interface ICommentManager
{
    Task<List<CommentReadDto>> GetAllCommentsAsync();
    Task<CommentReadDto> GetCommentByIdAsync(Guid id);
    Task CreateCommentAsync(Guid stockId, CommentCreateDto comment);
    Task DeleteCommentByIdAsync(Guid id);
    
    Task<bool> UpdateCommentAsync(Guid id, CommentUpdateDto comment);
}