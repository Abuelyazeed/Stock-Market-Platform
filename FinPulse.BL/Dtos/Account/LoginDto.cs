using System.ComponentModel.DataAnnotations;

namespace FinPulse.BL;

public class LoginDto
{
    [Required]
    public required string Username { get; set; }

    [Required] 
    public required string Password { get; set; }
}