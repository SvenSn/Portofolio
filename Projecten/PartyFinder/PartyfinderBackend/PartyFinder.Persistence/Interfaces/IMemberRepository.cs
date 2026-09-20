using System;

namespace PartyFinder.Persistence.Interfaces;

public interface IMemberRepository
{
    Task<Member> CreateMemberAsync(Member member);

    Task<Member?> GetMemberByIdAsync(Guid id);

    Task<List<Member>?> GetAllMembersAsync();

    Task<Member?> GetMemberByIdentityserverIdAsync(string IdentityserverId);

    Task<Member> UpdateMemberAsync(Member member);

    Task RemoveMemberAsync(Guid id);
}
