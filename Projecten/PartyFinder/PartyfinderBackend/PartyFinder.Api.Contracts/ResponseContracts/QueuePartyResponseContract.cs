using System;

namespace PartyFinder.Api.Contracts.ResponseContracts;

public class QueuePartyResponseContract
{
    public Guid Id { get; set; }
    public string Boss { get; set; } = null!;
    public int TargetSize { get; set; }
    public DateTime CreatedAt { get; set; }

    public List<MemberResponseContract> Members { get; set; }
}
