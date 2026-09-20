using Duende.IdentityServer;
using Duende.IdentityServer.Models;
using IdentityModel;

namespace PartyFinder.Identityserver;

public static class Config
{
    public static IEnumerable<IdentityResource> IdentityResources =>
        new IdentityResource[]
        {
            new IdentityResources.OpenId(),
            new IdentityResources.Profile(),
            new IdentityResource(name: "roles", userClaims: new[] { JwtClaimTypes.Role }),
        };
    public static IEnumerable<ApiResource> ApiResources =>
        new ApiResource[]
        {
            new ApiResource("partyfinder-api", "PartyFinder API")
            {
                Scopes = { "partyfinder.api.Read", "partyfinder.api.Write" },
                UserClaims = { JwtClaimTypes.Role },
            },
        };
    public static IEnumerable<ApiScope> ApiScopes =>
        new ApiScope[]
        {
            new ApiScope("partyfinder.api.Read", new[] { JwtClaimTypes.Role }),
            new ApiScope("partyfinder.api.Write", new[] { JwtClaimTypes.Role }),
        };

    public static IEnumerable<Client> Clients =>
        new Client[]
        {
            // m2m client credentials flow client
            new Client
            {
                ClientId = "postman-client",
                ClientName = "Client Credentials Client",

                AllowedGrantTypes = GrantTypes.ClientCredentials,
                ClientSecrets =
                {
                    new Secret((Environment.GetEnvironmentVariable("PARTYFINDER_POSTMAN_CLIENT_SECRET")
                        ?? throw new InvalidOperationException(
                            "Stel PARTYFINDER_POSTMAN_CLIENT_SECRET in.")).Sha256()),
                },

                AllowedScopes =
                {
                    "partyfinder.api.All",
                    "partyfinder.api.Write",
                    IdentityServerConstants.StandardScopes.OpenId,
                    IdentityServerConstants.StandardScopes.Profile,
                    "roles",
                },
            },
            new Client
            {
                ClientId = "webapp-client",
                RequireClientSecret = false,
                RequirePkce = true,
                AllowedGrantTypes = GrantTypes.Code,
                AllowedScopes =
                {
                    IdentityServerConstants.StandardScopes.OpenId,
                    IdentityServerConstants.StandardScopes.Profile,
                    "partyfinder.api.Read",
                    "partyfinder.api.Write",
                    "roles",
                },
                RedirectUris =
                {
                    "https://hogent-partyfinderfrontend-svensnoeck-efcjbsenduhye5h7.northeurope-01.azurewebsites.net/",
                },
                PostLogoutRedirectUris =
                {
                    "https://hogent-partyfinderfrontend-svensnoeck-efcjbsenduhye5h7.northeurope-01.azurewebsites.net/",
                },
                AllowedCorsOrigins =
                [
                    "https://hogent-partyfinderfrontend-svensnoeck-efcjbsenduhye5h7.northeurope-01.azurewebsites.net/",
                ],
            },
        };
}
