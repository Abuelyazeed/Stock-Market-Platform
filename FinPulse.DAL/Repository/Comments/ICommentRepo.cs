namespace FinPulse.DAL;

public interface ICommentRepo
{
    Task<List<Comment>> GetCommentsAsync(CommentParams commentParams);
    Task<Comment?> GetCommentAsync(int id);
    Task CreateCommentAsync(Comment comment);
    void DeleteComment(Comment comment);
    Task<int> SaveChangesAsync();
}