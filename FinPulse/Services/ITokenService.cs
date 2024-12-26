using FinPulse.DAL;

namespace FinPulse.Services;

public interface ITokenService
{
    string GenerateToken(AppUser user);
}