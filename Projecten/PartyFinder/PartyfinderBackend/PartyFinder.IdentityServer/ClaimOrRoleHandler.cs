using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;

public class ClaimOrRoleHandler : AuthorizationHandler<ClaimOrRoleRequirement>
{
    protected override Task HandleRequirementAsync(
        AuthorizationHandlerContext context,
        ClaimOrRoleRequirement requirement
    )
    {
        // Check for claim
        if (context.User.HasClaim(c => c.Type == requirement.Claim))
        {
            context.Succeed(requirement);
            return Task.CompletedTask;
        }

        if (requirement.Roles.Any(role => context.User.IsInRole(role)))
        {
            context.Succeed(requirement);
        }

        return Task.CompletedTask;
    }
}
