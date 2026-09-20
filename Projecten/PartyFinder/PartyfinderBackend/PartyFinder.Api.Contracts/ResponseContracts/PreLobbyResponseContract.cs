using System;

namespace PartyFinder.Api.Contracts.ResponseContracts;

public class PreLobbyResponseContract
{
    public Guid Id { get; set; }
    public string Boss { get; set; } = null!;

    public string PreLobbyState { get; set; }
    public string LeaderId { get; set; }

    public Guid InviteToken { get; set; }
    public DateTime CreatedAt { get; set; }

    public int TargetSize { get; set; }

    public int MaxSize { get; set; }
    public List<MemberResponseContract> Members { get; set; }
}
