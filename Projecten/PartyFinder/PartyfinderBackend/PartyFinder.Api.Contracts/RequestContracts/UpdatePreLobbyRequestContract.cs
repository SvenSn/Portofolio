using System;

namespace PartyFinder.Api.Contracts.RequestContracts;

public class UpdatePreLobbyRequestContract
{
    public Guid Id { get; set; }
    public BossType? Boss { get; set; }

    public Guid? LeaderId { get; set; }
}
