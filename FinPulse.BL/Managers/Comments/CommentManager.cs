using FinPulse.DAL;

namespace FinPulse.BL;

public class CommentManager : ICommentManager
{
    private readonly ICommentRepo _commentRepo;

    public CommentManager(ICommentRepo commentRepo)
    {
        _commentRepo = commentRepo;
    }

    public async Task<List<CommentReadDto>> GetAllCommentsAsync()
    {
        List<Comment> comments = await _commentRepo.GetAllCommentsAsync();

        List<CommentReadDto> commentReadDtos = comments.Select(comment => new CommentReadDto
        {
            Id = comment.Id,
            Title = comment.Title,
            Content = comment.Content,
            CreatedOn = comment.CreatedOn,
            StockId = comment.StockId,

        }).ToList();
        
        return commentReadDtos;
    }

    public async Task<CommentReadDto> GetCommentByIdAsync(Guid id)
    {
        Comment commentFromDb = await _commentRepo.GetCommentByIdAsync(id);
        CommentReadDto comment = new CommentReadDto()
        {
            Id = commentFromDb.Id,
            Title = commentFromDb.Title,
            Content = commentFromDb.Content,
            CreatedOn = commentFromDb.CreatedOn,
            StockId = commentFromDb.StockId,
        };
        
        return comment;
    }

    public async Task CreateCommentAsync(Guid stockId, CommentCreateDto Createdcomment)
    {
        Comment comment = new Comment()
        {
            Title = Createdcomment.Title,
            Content = Createdcomment.Content,
            CreatedOn = DateTime.Now,
            StockId = stockId,
        };
        
        await _commentRepo.CreateCommentAsync(comment);
        await _commentRepo.SaveChanges();
    }

    public async Task<bool> UpdateCommentAsync(Guid id, CommentUpdateDto commentUpdateDto)
    {
        Comment? commentFromDb = await _commentRepo.GetCommentByIdAsync(id);
        if(commentFromDb == null) return false;

        commentFromDb.Title = commentUpdateDto.Title;
        commentFromDb.Content = commentUpdateDto.Content;
            
        int numberOfAffectedRows = await _commentRepo.SaveChanges();
        return numberOfAffectedRows > 0;
    }
    
    public async Task DeleteCommentByIdAsync(Guid id)
    { 
        await _commentRepo.DeleteCommentAsync(id);
        await _commentRepo.SaveChanges();
    }
}