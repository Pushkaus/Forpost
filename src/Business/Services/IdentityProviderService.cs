using System.Security.Claims;
using Microsoft.AspNetCore.Http;

namespace Forpost.Business.Services;

public class IdentityProviderService
{
    private readonly IHttpContextAccessor _httpContextAccessor;

    public IdentityProviderService(IHttpContextAccessor httpContextAccessor)
    {
        _httpContextAccessor = httpContextAccessor;
    }

    public Guid GetUserId()
    {
        var user = _httpContextAccessor.HttpContext?.User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;
        if (user == null)
        {
            throw new UnauthorizedAccessException("User not found.");
        }
        return Guid.Parse(user);
    }
}