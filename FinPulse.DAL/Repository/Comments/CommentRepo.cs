using Microsoft.EntityFrameworkCore;

namespace FinPulse.DAL;

public class CommentRepo : ICommentRepo
{
    private readonly FinPulseContext _context;

    public CommentRepo(FinPulseContext context)
    {
        _context = context;
    }
    
    public async Task<List<Comment>> GetCommentsAsync()
    {
        return await _context.Comments.ToListAsync();
    }

    public async Task<Comment?> GetCommentAsync(int id)
    {
        return await _context.Comments.FindAsync(id);
    }

    public async Task CreateCommentAsync(Comment comment)
    {
         await _context.Comments.AddAsync(comment);
    }

    public void DeleteComment(Comment comment)
    {
        _context.Comments.Remove(comment);
    }

    public Task<int> SaveChangesAsync()
    {
        return _context.SaveChangesAsync();
    }
}