using System;
using System.Diagnostics.Contracts;
using PartyFinder.Api.Contracts.RequestContracts;
using PartyFinder.Api.Contracts.ResponseContracts;
using PartyFinder.Domain.Services.Interfaces;
using PartyFinder.Domain.Services.Mapping;
using PartyFinder.Persistence.Interfaces;
using PartyFinder.Persistence.Repositories;

namespace PartyFinder.Domain.Services;

public class QueuePartyService(
    IQueuePartyRepository repo,
    IUnitOfWork uow,
    IMemberRepository memberRepo,
    IPreLobbyRepository preLobbyRepo
) : IQuePartyService
{
    public async Task<QueuePartyResponseContract> CreateQueuePartyAsync(
        QueuePartyRequestContract queueParty
    )
    {
        var entity = queueParty.AsEntity();
        var members = new List<Member>();

        foreach (var memberid in queueParty.MemberIds)
        {
            var member = await memberRepo.GetMemberByIdAsync(memberid);
            if (member != null)
            {
                members.Add(member);
            }
        }

        entity.Members = members;

        await repo.CreateQueuePartyAsync(entity);
        await uow.SaveChangesAsync();

        foreach (var member in members)
        {
            member.QueuePartyId = entity.Id;
            member.State = MemberState.InQueueParty;
        }
        await uow.SaveChangesAsync();

        return entity.AsContract();
    }

    public async Task<List<QueuePartyResponseContract>?> GetAllQueuePartiesAsync()
    {
        var result = await repo.GetAllQueuePartiesAsync();

        if (result is null)
            return null;

        return result.Select(q => q.AsContract()).ToList();
    }

    public async Task<QueuePartyResponseContract?> GetQueuePartyByIdAsync(Guid id)
    {
        var result = await repo.GetQueuePartyByIdAsync(id);

        if (result == null)
            return null;

        return result.AsContract();
    }

    public async Task<QueuePartyResponseContract> JoinQueueAsync(Guid prelobbyId)
    {
        var prelobby = await preLobbyRepo.GetPreLobbyById(prelobbyId);

        if (prelobby == null)
            throw new Exception("PreLobby not found");
        if (prelobby.Members == null)
        {
            throw new Exception("PreLobby members not found");
        }
        var queueParty = new QueueParty
        {
            Boss = prelobby.Boss,
            TargetSize = prelobby.TargetSize,
            Members = prelobby.Members,
        };

        await repo.CreateQueuePartyAsync(queueParty);
        await uow.SaveChangesAsync();

        foreach (var member in prelobby.Members)
        {
            member.QueuePartyId = queueParty.Id;
            member.State = MemberState.InQueueParty;
        }

        await uow.SaveChangesAsync();

        return queueParty.AsContract();
    }

    public async Task LeaveQueueAsync(Guid queuePartyId)
    {
        var party = await repo.GetQueuePartyByIdAsync(queuePartyId);
        if (party is null)
            return;

        foreach (var member in party.Members)
        {
            member.QueuePartyId = null;
            member.State = MemberState.InPreLobby;
        }

        await repo.RemoveQueuePartyAsync(party);
        await uow.SaveChangesAsync();
    }

    public async Task RemoveQueuePartyAsync(Guid id)
    {
        var party = await repo.GetQueuePartyByIdAsync(id);

        await repo.RemoveQueuePartyAsync(party);

        await uow.SaveChangesAsync();
    }

    public async Task<QueuePartyResponseContract?> UpdateQueuePartyAsync(
        UpdateQueuePartyRequestContract partyToUpdate
    )
    {
        var party = await repo.GetQueuePartyByIdAsync(partyToUpdate.Id);

        if (party is null)
            return null;

        if (!string.IsNullOrEmpty(partyToUpdate.Boss))
        {
            party.Boss = partyToUpdate.Boss;
        }

        if (partyToUpdate.TargetSize.HasValue)
        {
            party.TargetSize = partyToUpdate.TargetSize.Value;
        }

        await repo.UpdateQueuePartyAsync(party);

        await uow.SaveChangesAsync();

        return party.AsContract();
    }
}
