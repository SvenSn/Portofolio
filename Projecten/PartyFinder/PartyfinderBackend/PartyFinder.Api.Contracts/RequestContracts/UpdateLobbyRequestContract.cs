using System;

namespace PartyFinder.Api.Contracts.RequestContracts;

public class UpdateLobbyRequestContract
{
    public Guid Id { get; set; }
    public string? Boss { get; set; }
    public bool? IsActive { get; set; }
}
