using System.Security.Claims;

namespace Datagaucha.API.Utils;

public static class ClaimsPrincipalExtensions
{
    public static long GetUserId(this ClaimsPrincipal user)
    {
        var value = user.FindFirstValue(ClaimTypes.NameIdentifier);

        if (!long.TryParse(value, out var userId))
        {
            throw new UnauthorizedAccessException();
        }

        return userId;
    }
}
