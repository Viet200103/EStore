using System.Security.Authentication;
using System.Security.Claims;

namespace EStore.Business.Security;

public class UserHelper
{
    private ClaimsIdentity? _identity;

    public UserHelper(ClaimsPrincipal claimsPrincipal)
    {
        _identity = claimsPrincipal.Identity as ClaimsIdentity;
        if (_identity == null)
        {
            throw new AuthenticationException("Identity is not a ClaimsIdentity");
        }
    }

    public string? GetEmail()
    {
        return _identity?.FindFirst(ClaimTypes.Email)?.Value;
    }

    public short GetUserId()
    {
        var userId = short.Parse(_identity?.FindFirst(ClaimTypes.NameIdentifier)?.Value ?? "-1");
        return userId;
    }
}