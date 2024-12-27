using Microsoft.AspNetCore.Identity;

namespace FinPulse.DAL;

public class AppUser : IdentityUser
{
    public List<Portfolio> Portfolios { get; set; } = [];
}