using System.Security.Claims;
using Forpost.Common.Utils;

namespace Forpost.Host.Infrastructure.Auth;

internal sealed class IdentityProvider : IIdentityProvider
{
    private readonly IHttpContextAccessor _httpContextAccessor;

    public IdentityProvider(IHttpContextAccessor httpContextAccessor)
    {
        _httpContextAccessor = httpContextAccessor;
    }

    public Guid? GetUserId() => GetClaimValue(ClaimTypes.NameIdentifier);
    
    public Guid? GetRoleId() => GetClaimValue(ClaimTypes.Role);
    
    private Guid? GetClaimValue(string claimType)
    {
        var claimValue = _httpContextAccessor.HttpContext?.User.Claims
            .FirstOrDefault(c => c.Type == claimType)?.Value;

        if (Guid.TryParse(claimValue, out var result)) 
            return result;

        return null;
    }
}