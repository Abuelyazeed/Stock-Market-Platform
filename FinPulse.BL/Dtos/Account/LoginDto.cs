using System.ComponentModel.DataAnnotations;

namespace FinPulse.BL;

public class LoginDto
{
    [Required]
    public string Username { get; set; }

    [Required] 
    public string Password { get; set; }
}