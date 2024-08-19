using System.Security.Claims;
using Microsoft.AspNetCore.Http;

namespace Forpost.Common.Utils;

internal sealed class IdentityProvider : IIdentityProvider
{
    private readonly IHttpContextAccessor _httpContextAccessor;

    public IdentityProvider(IHttpContextAccessor httpContextAccessor)
    {
        _httpContextAccessor = httpContextAccessor;
    }

    public Guid GetUserId()
    {
        var user = _httpContextAccessor.HttpContext?.User.Claims
            .FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;
        if (user == null) throw new UnauthorizedAccessException("User not found.");
        return Guid.Parse(user);
    }
}