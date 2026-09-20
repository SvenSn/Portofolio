using System;
using PartyFinder.Identityserver.Contracts;
using PartyFinder.Identityserver.Models;
using PartyFinder.Identityserver.Repositories.Interfaces;
using PartyFinder.Identityserver.Services.Interfaces;

namespace PartyFinder.Identityserver.Services;

public class UserService(IPlayerRepository playerRepo) : IUserService
{
    public async Task<PlayerResponseContract> CreatePlayer(PlayerRequestContract player)
    {
        var entity = player.AsEntity();

        var result = await playerRepo.CreatePlayer(entity, player.Password);

        return result.AsContract();
    }

    public async Task RemovePlayer(string identityServerId)
    {
        await playerRepo.DeletePlayer(identityServerId);
    }
}

public static class PlayerMappingExtensions
{
    public static PlayerResponseContract AsContract(this ApplicationUser user)
    {
        return new PlayerResponseContract
        {
            Id = Guid.Parse(user.Id),
            Email = user.Email,
            UserName = user.UserName,
        };
    }

    public static ApplicationUser AsEntity(this PlayerRequestContract contract)
    {
        return new ApplicationUser { Email = contract.Email, UserName = contract.UserName };
    }
}
