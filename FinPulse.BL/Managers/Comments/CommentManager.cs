using FinPulse.DAL;

namespace FinPulse.BL;

public class CommentManager : ICommentManager
{
    private readonly ICommentRepo _commentRepo;

    public CommentManager(ICommentRepo commentRepo)
    {
        _commentRepo = commentRepo;
    }

    public async Task<List<CommentDto>> GetCommentsAsync()
    {
        List<Comment> comments = await _commentRepo.GetCommentsAsync();

        List<CommentDto> commentsDto = comments.Select(comment => new CommentDto
        {
            Id = comment.Id,
            Title = comment.Title,
            Content = comment.Content,
            CreatedOn = comment.CreatedOn,
            CreatedBy = comment.AppUser!.UserName,
            StockId = comment.StockId,

        }).ToList();
        
        return commentsDto;
    }

    public async Task<CommentDto?> GetCommentAsync(int id)
    {
        Comment? commentFromDb = await _commentRepo.GetCommentAsync(id);

        if (commentFromDb == null)
        {
            return null;
        }
        
        CommentDto comment = new CommentDto()
        {
            Id = commentFromDb.Id,
            Title = commentFromDb.Title,
            Content = commentFromDb.Content,
            CreatedOn = commentFromDb.CreatedOn,
            CreatedBy = commentFromDb.AppUser!.UserName,
            StockId = commentFromDb.StockId,
        };
        
        return comment;
    }

    public async Task<CommentDto> CreateCommentAsync(int stockId, CommentCreateDto createdComment,string userId)
    {
        Comment commentFromDb = new Comment()
        {
            Title = createdComment.Title,
            Content = createdComment.Content,
            CreatedOn = DateTime.Now,
            StockId = stockId,
            AppUserId = userId
        };
        
        await _commentRepo.CreateCommentAsync(commentFromDb);
        await _commentRepo.SaveChangesAsync();
        
        CommentDto commentDto = new CommentDto()
        {
            Id = commentFromDb.Id,
            Title = commentFromDb.Title,
            Content = commentFromDb.Content,
            CreatedOn = commentFromDb.CreatedOn,
            CreatedBy = commentFromDb.AppUser!.UserName,
            StockId = commentFromDb.StockId,
        };
        
        return commentDto;
    }

    public async Task<CommentDto?> UpdateCommentAsync(int id, CommentUpdateDto commentUpdateDto)
    {
        Comment? commentFromDb = await _commentRepo.GetCommentAsync(id);
        if(commentFromDb == null) return null;

        commentFromDb.Title = commentUpdateDto.Title;
        commentFromDb.Content = commentUpdateDto.Content;
            
        await _commentRepo.SaveChangesAsync();
        return new CommentDto()
        {
            Id = commentFromDb.Id,
            Title = commentFromDb.Title,
            Content = commentFromDb.Content,
            CreatedOn = commentFromDb.CreatedOn,
            StockId = commentFromDb.StockId,
        };
    }
    
    public async Task<bool> DeleteCommentByIdAsync(int id)
    { 
        Comment? comment = await _commentRepo.GetCommentAsync(id);
        if(comment == null) return false;
        
        _commentRepo.DeleteComment(comment);
        await _commentRepo.SaveChangesAsync();
        return true;
    }
}