using System;
using PartyFinder.Identityserver.Contracts;

namespace PartyFinder.Identityserver.Services.Interfaces;

public interface IUserService
{
    Task<PlayerResponseContract> CreatePlayer(PlayerRequestContract player);

    Task RemovePlayer(string identityServerId);
}
