using System.Security.Claims;

namespace FinPulse.Extentions;

public static class ClaimsExtentions
{
    public static string getUsername(this ClaimsPrincipal user)
    {
        var username = user.FindFirstValue(ClaimTypes.GivenName);
        
        if (username == null) throw new Exception("Cannot get username from token");

        return username;
    }
    
    public static string getUserId(this ClaimsPrincipal user)
    {
        var userId = user.FindFirstValue(ClaimTypes.NameIdentifier)
                               ?? throw new Exception("Cannot get user id from token");

        return userId;
    }
}