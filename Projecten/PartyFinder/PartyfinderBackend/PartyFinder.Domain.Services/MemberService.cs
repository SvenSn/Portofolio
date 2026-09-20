using System;
using PartyFinder.Api.Contracts.RequestContracts;
using PartyFinder.Api.Contracts.ResponseContracts;
using PartyFinder.Domain.Services.Interfaces;
using PartyFinder.Domain.Services.Mapping;
using PartyFinder.Persistence.Interfaces;
using PartyFinder.Persistence.Repositories;

namespace PartyFinder.Domain.Services;

public class MemberService(
    IMemberRepository memberRepository,
    IUnitOfWork uow,
    IOsrsHiScoresService osrsHiScoresService
) : IMemberService
{
    public async Task<MemberResponseContract> CreateMemberAsync(MemberRequestContract contract)
    {
        var entity = contract.AsEntity();
        entity.State = MemberState.Idle;
        entity.AccountType = await osrsHiScoresService.GetAccountTypeAsync(contract.Username);
        var member = await memberRepository.CreateMemberAsync(entity);
        await uow.SaveChangesAsync();

        return member.AsContract();
    }

    public async Task<List<MemberResponseContract>?> GetAllMembersAsync()
    {
        var result = await memberRepository.GetAllMembersAsync();

        if (result == null)
            return null;

        return result.Select(m => m.AsContract()).ToList();
    }

    public async Task<MemberResponseContract?> GetMemberByIdAsync(Guid id)
    {
        var member = await memberRepository.GetMemberByIdAsync(id);

        if (member is null)
            return null;

        return member.AsContract();
    }

    public async Task<MemberResponseContract?> GetMemberByIdentityserverIdAsync(
        string indentityserverId
    )
    {
        var member = await memberRepository.GetMemberByIdentityserverIdAsync(indentityserverId);

        if (member is null)
            return null;

        return member.AsContract();
    }

    public async Task RemoveMemberAsync(Guid id)
    {
        await memberRepository.RemoveMemberAsync(id);

        await uow.SaveChangesAsync();
    }

    public async Task<MemberResponseContract?> UpdateMemberAsync(
        UpdateMemberRequestContract contract
    )
    {
        var member = await memberRepository.GetMemberByIdentityserverIdAsync(
            contract.identityserverid
        );
        if (member is null)
            return null;

        var result = await memberRepository.UpdateMemberAsync(member);

        return result.AsContract();
    }
}
