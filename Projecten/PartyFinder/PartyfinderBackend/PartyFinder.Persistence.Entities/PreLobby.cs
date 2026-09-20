using System;

namespace PartyFinder.Persistence.Entities;

public enum PreLobbyState
{
    Open, // invites allowed
    Queueing, // locked, waiting for matchmaking
    Matched, // match found, transitioning
    Closed,
}

public class PreLobby
{
    public Guid Id { get; set; }
    public string Boss { get; set; } = null!;

    public PreLobbyState PreLobbyState { get; set; }

    public Guid LeaderId { get; set; }

    public Guid InviteToken { get; set; } = Guid.NewGuid();
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    public int TargetSize { get; set; }

    public int MaxSize { get; set; } = 5;

    public ICollection<Member> Members { get; set; }
}
