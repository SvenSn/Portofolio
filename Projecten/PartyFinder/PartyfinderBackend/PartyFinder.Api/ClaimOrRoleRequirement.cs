using Microsoft.AspNetCore.Authorization;

public class ClaimOrRoleRequirement : IAuthorizationRequirement
{
    public string Claim { get; }
    public string[] Roles { get; }

    public ClaimOrRoleRequirement(string claim, params string[] roles)
    {
        Claim = claim;
        Roles = roles ?? [];
    }
}
