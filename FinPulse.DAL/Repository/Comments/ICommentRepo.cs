namespace FinPulse.DAL;

public interface ICommentRepo
{
    Task<List<Comment>> GetAllCommentsAsync();
}