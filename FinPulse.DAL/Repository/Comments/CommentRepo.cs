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

    public async Task CreateCommentAsync(Comment comment)
    {
         await _context.Comments.AddAsync(comment);
    }

    public async Task DeleteCommentAsync(Guid id)
    {
        var comment = await _context.Comments.FindAsync(id);
        if (comment != null)
        {
            _context.Comments.Remove(comment);
        }
        else
        {
            throw new Exception("Comment not found.");
        }
        
    }

    public Task<int> SaveChanges()
    {
        return _context.SaveChangesAsync();
    }
}