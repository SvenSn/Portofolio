using System;
using PartyFinder.Api.Contracts.RequestContracts;
using PartyFinder.Api.Contracts.ResponseContracts;

namespace PartyFinder.Domain.Services.Interfaces;

public interface IMemberService
{
    Task<MemberResponseContract> CreateMemberAsync(MemberRequestContract contract);

    Task<MemberResponseContract?> GetMemberByIdAsync(Guid id);

    Task<List<MemberResponseContract>?> GetAllMembersAsync();

    Task<MemberResponseContract?> GetMemberByIdentityserverIdAsync(string indentityserverId);

    Task<MemberResponseContract?> UpdateMemberAsync(UpdateMemberRequestContract contract);

    Task RemoveMemberAsync(Guid id);
}
