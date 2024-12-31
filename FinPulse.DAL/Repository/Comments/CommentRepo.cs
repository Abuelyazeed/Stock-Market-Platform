using Microsoft.EntityFrameworkCore;

namespace FinPulse.DAL;

public class CommentRepo : ICommentRepo
{
    private readonly FinPulseContext _context;

    public CommentRepo(FinPulseContext context)
    {
        _context = context;
    }
    
    public async Task<List<Comment>> GetCommentsAsync(CommentParams commentParams)
    {
        var comments = _context.Comments.Include(x => x.AppUser).AsQueryable();
        
        //Filter byy symbol
        if (!string.IsNullOrWhiteSpace(commentParams.Symbol))
        {
            comments = comments.Where(c => c.Stock!.Symbol.ToLower() == commentParams.Symbol.ToLower());
        }

        //sort
        if (commentParams.IsDecsending)
        {
            comments = comments.OrderByDescending(c => c.CreatedOn);
        }
        return await comments.ToListAsync();
    }

    public async Task<Comment?> GetCommentAsync(int id)
    {
        return await _context.Comments.Include(x => x.AppUser).FirstOrDefaultAsync(x => x.Id == id);
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