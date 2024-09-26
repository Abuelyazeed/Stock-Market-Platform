using System.ComponentModel.DataAnnotations;

namespace FinPulse.BL;

public class CommentUpdateDto
{
    [Required]
    [MinLength(5, ErrorMessage = "Comment title must be at least 5 characters long.")]
    [MaxLength(280, ErrorMessage = "Comment title must be less than 280 characters long.")]
    public string Title { get; set; } = string.Empty;
    [Required]
    [MinLength(5, ErrorMessage = "Comment content must be at least 5 characters long.")]
    [MaxLength(280, ErrorMessage = "Comment content must be less than 280 characters long.")]
    public string Content { get; set; } = string.Empty;
}