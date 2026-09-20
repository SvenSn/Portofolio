using System;

namespace PartyFinder.Api.Contracts.ResponseContracts;

public class LobbyResponseContract
{
    public Guid Id { get; set; }
    public string Boss { get; set; } = null!;
    public bool IsActive { get; set; }
    public DateTime CreatedAt { get; set; }

    public DateTime? FinishedAt { get; set; }

    public List<MemberResponseContract> Members { get; set; }
}
