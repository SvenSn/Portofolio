using System;
using System.Security.Claims;
using IdentityModel;
using Microsoft.AspNetCore.Identity;
using PartyFinder.Identityserver.Models;
using PartyFinder.Identityserver.Repositories.Interfaces;

namespace PartyFinder.Identityserver.Repositories;

public class PlayerRepository(UserManager<ApplicationUser> userManager) : IPlayerRepository
{
    public async Task<ApplicationUser> CreatePlayer(ApplicationUser player, string password)
    {
        var result = await userManager.CreateAsync(player, password);
        if (!result.Succeeded)
            throw new InvalidOperationException(
                string.Join(", ", result.Errors.Select(e => e.Description))
            );

        await userManager.AddToRoleAsync(player, "User");

        await userManager.AddClaimsAsync(
            player,
            new Claim[]
            {
                new Claim(JwtClaimTypes.PreferredUserName, player.UserName),
                new Claim(JwtClaimTypes.Email, player.Email),
            }
        );

        return player;
    }

    public async Task DeletePlayer(string identityServerId)
    {
        var user = await userManager.FindByIdAsync(identityServerId);
        if (user != null)
            await userManager.DeleteAsync(user);
    }
}
