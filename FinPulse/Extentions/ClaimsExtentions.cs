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
}