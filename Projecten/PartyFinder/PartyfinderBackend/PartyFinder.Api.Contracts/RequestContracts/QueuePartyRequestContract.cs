using System;

namespace PartyFinder.Api.Contracts.RequestContracts;

public class QueuePartyRequestContract
{
    public string Boss { get; set; } = null!;
    public int TargetSize { get; set; }

    public List<Guid> MemberIds { get; set; }
}
