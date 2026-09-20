using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using PartyFinder.Persistence.Entities;
using PartyFinder.Persistence.Interfaces;

namespace PartyFinder.Persistence;

public class MemberRepository(PartyFinderDBContext context) : IMemberRepository
{
    public async Task<Member> CreateMemberAsync(Member member)
    {
        await context.Members.AddAsync(member);

        return member;
    }

    public async Task<List<Member>?> GetAllMembersAsync()
    {
        var members = await context.Members.ToListAsync();

        return members;
    }

    public async Task<Member?> GetMemberByIdAsync(Guid id)
    {
        var member = await context.Members.FirstOrDefaultAsync(m => m.Id == id);
        if (member is null)
            throw new ArgumentNullException($"Member with id {id} cannot be found");

        return member;
    }

    public async Task<Member?> GetMemberByIdentityserverIdAsync(string IdentityserverId)
    {
        var member = await context.Members.FirstOrDefaultAsync(m =>
            m.IdentityServerId == IdentityserverId
        );

        if (member is null)
            throw new ArgumentNullException(
                $"Member with identityserverid {IdentityserverId} cannot be found."
            );

        return member;
    }

    public async Task RemoveMemberAsync(Guid id)
    {
        var member = await context.Members.FirstOrDefaultAsync(m => m.Id == id);
        if (member is null)
            throw new ArgumentNullException($"Member with id {id} cannot be found");

        context.Remove(member);
    }

    public Task<Member> UpdateMemberAsync(Member member)
    {
        context.Update(member);

        return Task.FromResult(member);
    }
}
