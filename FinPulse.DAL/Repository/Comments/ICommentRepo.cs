namespace FinPulse.DAL;

public interface ICommentRepo
{
    Task<List<Comment>> GetAllCommentsAsync();
    Task<Comment> GetCommentByIdAsync(int id);
    Task CreateCommentAsync(Comment comment);
    Task DeleteCommentAsync(int id);
    Task<int> SaveChanges();
}