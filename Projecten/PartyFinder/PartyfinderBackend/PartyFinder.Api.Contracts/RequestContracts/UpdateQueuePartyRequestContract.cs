using System;

namespace PartyFinder.Api.Contracts.RequestContracts;

public class UpdateQueuePartyRequestContract
{
    public Guid Id { get; set; }
    public string? Boss { get; set; }
    public int? TargetSize { get; set; }
}
