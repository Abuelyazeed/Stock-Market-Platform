namespace FinPulse.DAL;

public interface ICommentRepo
{
    Task<List<Comment>> GetAllCommentsAsync();
    Task<Comment> GetCommentByIdAsync(Guid id);
    Task CreateCommentAsync(Comment comment);
    Task DeleteCommentAsync(Guid id);
    Task<int> SaveChanges();
}