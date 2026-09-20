using System.Security.Claims;
using Duende.IdentityServer.EntityFramework.DbContexts;
using Duende.IdentityServer.EntityFramework.Mappers;
using IdentityModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using PartyFinder.Identityserver.Data;
using PartyFinder.Identityserver.Models;
using Serilog;

namespace PartyFinder.Identityserver;

public class SeedData
{
    public static void EnsureSeedData(WebApplication app)
    {
        using (var scope1 = app.Services.GetRequiredService<IServiceScopeFactory>().CreateScope())
        {
            var context2 = scope1.ServiceProvider.GetRequiredService<ConfigurationDbContext>();

            Log.Debug("Overwriting db clients with Config.cs");
            context2.Clients.RemoveRange(context2.Clients);
            foreach (var client in Config.Clients)
                context2.Clients.Add(client.ToEntity());
            context2.SaveChanges();
            Log.Debug("Clients overwrite done");

            Log.Debug("Adding IdentityResources");
            foreach (var resource in Config.IdentityResources)
                if (!context2.IdentityResources.Any(db => resource.Name == db.Name))
                    context2.IdentityResources.Add(resource.ToEntity());
            context2.SaveChanges();
            Log.Debug("Adding IdentityResources done");

            Log.Debug("Adding ApiScopes");
            foreach (var resource in Config.ApiScopes)
                if (!context2.ApiScopes.Any(db => resource.Name == db.Name))
                    context2.ApiScopes.Add(resource.ToEntity());
            context2.SaveChanges();
            Log.Debug("Adding ApiScopes done");

            using (
                var scope = app.Services.GetRequiredService<IServiceScopeFactory>().CreateScope()
            )
            {
                var context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
                context.Database.Migrate();

                var userMgr = scope.ServiceProvider.GetRequiredService<
                    UserManager<ApplicationUser>
                >();
                var alice = userMgr.FindByNameAsync("alice").Result;
                if (alice == null)
                {
                    alice = new ApplicationUser
                    {
                        UserName = "alice",
                        Email = "AliceSmith@email.com",
                        EmailConfirmed = true,
                    };
                    var result = userMgr.CreateAsync(alice, "Pass123$").Result;
                    if (!result.Succeeded)
                    {
                        throw new Exception(result.Errors.First().Description);
                    }

                    result = userMgr
                        .AddClaimsAsync(
                            alice,
                            new Claim[]
                            {
                                new Claim(JwtClaimTypes.Name, "Alice Smith"),
                                new Claim(JwtClaimTypes.GivenName, "Alice"),
                                new Claim(JwtClaimTypes.FamilyName, "Smith"),
                                new Claim(JwtClaimTypes.WebSite, "http://alice.com"),
                            }
                        )
                        .Result;
                    if (!result.Succeeded)
                    {
                        throw new Exception(result.Errors.First().Description);
                    }
                    Log.Debug("alice created");
                }
                else
                {
                    Log.Debug("alice already exists");
                }

                var bob = userMgr.FindByNameAsync("bob").Result;
                if (bob == null)
                {
                    bob = new ApplicationUser
                    {
                        UserName = "bob",
                        Email = "BobSmith@email.com",
                        EmailConfirmed = true,
                    };
                    var result = userMgr.CreateAsync(bob, "Pass123$").Result;
                    if (!result.Succeeded)
                    {
                        throw new Exception(result.Errors.First().Description);
                    }

                    result = userMgr
                        .AddClaimsAsync(
                            bob,
                            new Claim[]
                            {
                                new Claim(JwtClaimTypes.Name, "Bob Smith"),
                                new Claim(JwtClaimTypes.GivenName, "Bob"),
                                new Claim(JwtClaimTypes.FamilyName, "Smith"),
                                new Claim(JwtClaimTypes.WebSite, "http://bob.com"),
                                new Claim("location", "somewhere"),
                            }
                        )
                        .Result;
                    if (!result.Succeeded)
                    {
                        throw new Exception(result.Errors.First().Description);
                    }
                    Log.Debug("bob created");
                }
                else
                {
                    Log.Debug("bob already exists");
                }
                var roleMgr = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
                string[] roles = new[] { "Admin", "User" };
                foreach (var role in roles)
                {
                    if (!roleMgr.RoleExistsAsync(role).Result)
                    {
                        var result = roleMgr.CreateAsync(new IdentityRole(role)).Result;
                        if (!result.Succeeded)
                        {
                            throw new Exception(result.Errors.First().Description);
                        }
                        Log.Debug($"{role} role created");
                    }
                    else
                    {
                        Log.Debug($"{role} role already exists");
                    }
                }

                // Optionally assign roles to users:
                if (!userMgr.IsInRoleAsync(alice, "User").Result)
                {
                    userMgr.AddToRoleAsync(alice, "User").Wait();
                }
                if (!userMgr.IsInRoleAsync(bob, "Admin").Result)
                {
                    userMgr.AddToRoleAsync(bob, "Admin").Wait();
                }

                var configContext =
                    scope.ServiceProvider.GetRequiredService<ConfigurationDbContext>();

                // 1. Create the API Resource if it doesn't exist
                var apiResource = configContext
                    .ApiResources.Include(x => x.UserClaims)
                    .FirstOrDefault(x => x.Name == "partyfinder-api");

                if (apiResource == null)
                {
                    apiResource = new Duende.IdentityServer.EntityFramework.Entities.ApiResource
                    {
                        Name = "partyfinder-api",
                        DisplayName = "PartyFinder API",
                    };
                    configContext.ApiResources.Add(apiResource);
                    configContext.SaveChanges();

                    // Reload with Id populated
                    apiResource = configContext
                        .ApiResources.Include(x => x.UserClaims)
                        .FirstOrDefault(x => x.Name == "partyfinder-api");
                }

                // 2. Add the role claim if missing
                if (!apiResource.UserClaims.Any(c => c.Type == JwtClaimTypes.Role))
                {
                    apiResource.UserClaims.Add(
                        new Duende.IdentityServer.EntityFramework.Entities.ApiResourceClaim
                        {
                            Type = JwtClaimTypes.Role,
                        }
                    );
                    configContext.SaveChanges();
                }
            }
        }
    }
}
