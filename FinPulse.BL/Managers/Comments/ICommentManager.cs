namespace FinPulse.BL;

public interface ICommentManager
{
    Task<List<CommentReadDto>> GetAllCommentsAsync();
}