using System;

namespace PartyFinder.Persistence.Entities;

public class Lobby
{
    public Guid Id { get; set; }
    public string Boss { get; set; } = null!;
    public bool IsActive { get; set; } = true;
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    public DateTime? FinishedAt { get; set; }

    public ICollection<Member> Members { get; set; }
}
