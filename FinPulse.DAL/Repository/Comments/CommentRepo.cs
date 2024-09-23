using Microsoft.EntityFrameworkCore;

namespace FinPulse.DAL;

public class CommentRepo : ICommentRepo
{
    private readonly FinPulseContext _context;

    public CommentRepo(FinPulseContext context)
    {
        _context = context;
    }
    
    public async Task<List<Comment>> GetAllCommentsAsync()
    {
        return await _context.Comments.ToListAsync();
    }

    public async Task<Comment> GetCommentByIdAsync(Guid id)
    {
        return await _context.Comments.FindAsync(id);
    }
}