namespace FinPulse.DAL;

public interface ICommentRepo
{
    Task<List<Comment>> GetCommentsAsync();
    Task<Comment?> GetCommentAsync(int id);
    Task CreateCommentAsync(Comment comment);
    void DeleteCommentAsync(Comment comment);
    Task<int> SaveChanges();
}