using System;
using Duende.IdentityModel.Client;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;

namespace ShipIt.PriceQuote.Api;

public class PartyfinderAuthHandler : AuthorizationHandler<ClaimOrRoleRequirement>
{
    private readonly IHttpContextAccessor _httpContextAccessor;

    public PartyfinderAuthHandler(IHttpContextAccessor httpContextAccessor)
    {
        _httpContextAccessor = httpContextAccessor;
    }

    protected override Task HandleRequirementAsync(
        AuthorizationHandlerContext context,
        ClaimOrRoleRequirement requirement
    )
    {
        var claims = context.User.Claims.ToList();

        // Check for required claim (scope)
        if (!claims.Exists(c => c.Value == requirement.Claim))
        {
            context.Fail();
            return Task.CompletedTask;
        }

        var userId = claims.FirstOrDefault(c => c.Type == "sub")?.Value;

        if (userId is not null)
        {
            var client = new HttpClient();
            var disco = client.GetDiscoveryDocumentAsync("https://localhost:5001").Result;
            var token = _httpContextAccessor.HttpContext.GetTokenAsync("access_token").Result;

            var request = new UserInfoRequest { Address = disco.UserInfoEndpoint, Token = token };

            var userInfo = client.GetUserInfoAsync(request).Result;

            // Check if user has any allowed role
            if (
                userInfo
                    .Claims.ToList()
                    .Any(c => c.Type == "role" && requirement.Roles.Contains(c.Value))
            )
            {
                context.Succeed(requirement);
            }
            else
            {
                context.Fail();
            }
        }
        else
        {
            // System client (no user) - OK if claim is present
            context.Succeed(requirement);
        }

        return Task.CompletedTask;
    }
}
