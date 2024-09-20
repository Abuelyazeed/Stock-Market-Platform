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
}