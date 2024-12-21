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
            StockId = commentFromDb.StockId,
        };
        
        return comment;
    }

    public async Task<int> CreateCommentAsync(int stockId, CommentCreateDto createdComment)
    {
        Comment comment = new Comment()
        {
            Title = createdComment.Title,
            Content = createdComment.Content,
            CreatedOn = DateTime.Now,
            StockId = stockId,
        };
        
        await _commentRepo.CreateCommentAsync(comment);
        await _commentRepo.SaveChanges();
        
        return comment.Id;
    }

    public async Task<CommentDto?> UpdateCommentAsync(int id, CommentUpdateDto commentUpdateDto)
    {
        Comment? commentFromDb = await _commentRepo.GetCommentAsync(id);
        if(commentFromDb == null) return null;

        commentFromDb.Title = commentUpdateDto.Title;
        commentFromDb.Content = commentUpdateDto.Content;
            
        await _commentRepo.SaveChanges();
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
        
        _commentRepo.DeleteCommentAsync(comment);
        await _commentRepo.SaveChanges();
        return true;
    }
}