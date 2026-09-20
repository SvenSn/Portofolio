using System;

namespace PartyFinder.Api.Contracts.RequestContracts;

public class LobbyRequestContract
{
    public string Boss { get; set; }

    public List<Guid> MemberIds { get; set; }
}
