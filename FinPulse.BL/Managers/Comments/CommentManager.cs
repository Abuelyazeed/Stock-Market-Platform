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
            // StockId = comment.StockId,

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
        };
        
        return comment;
    }
}