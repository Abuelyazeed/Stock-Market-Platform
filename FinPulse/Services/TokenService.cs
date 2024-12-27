using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using FinPulse.DAL;
using Microsoft.IdentityModel.Tokens;
using JwtRegisteredClaimNames = Microsoft.IdentityModel.JsonWebTokens.JwtRegisteredClaimNames;

namespace FinPulse.Services;

public class TokenService(IConfiguration config) : ITokenService
{
    public string GenerateToken(AppUser user)
    {
        var signingKey = config["SigningKey"] ?? throw new Exception("Cannot access signingKey from settings");
        if(signingKey.Length < 64) throw new Exception("Your signingKey needs to be longer");
        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(signingKey));
        
        if(user.UserName == null || user.Email == null) throw new Exception("No username or email for user");

        var claims = new List<Claim>
        {
            new Claim(ClaimTypes.Email, user.Email),
            new Claim(ClaimTypes.GivenName, user.UserName),
            new Claim(ClaimTypes.NameIdentifier, user.Id)
        };

        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(claims),
            Expires = DateTime.Now.AddDays(7),
            SigningCredentials = creds,
        };

        var tokenHandler = new JwtSecurityTokenHandler();

        var token = tokenHandler.CreateToken(tokenDescriptor);

        return tokenHandler.WriteToken(token);
    }
}