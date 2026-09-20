using System;
using PartyFinder.Api.Contracts.RequestContracts;
using PartyFinder.Api.Contracts.ResponseContracts;
using PartyFinder.Persistence.Entities;

namespace PartyFinder.Domain.Services.Mapping;

public static class MemberMappingExtensions
{
    public static MemberResponseContract AsContract(this Member entity)
    {
        return new MemberResponseContract(
            entity.Id,
            entity.Username,
            entity.IdentityServerId,
            entity.AccountType,
            entity.State.ToString()
        );
    }

    public static Member AsEntity(this MemberRequestContract contract)
    {
        return new Member
        {
            Username = contract.Username,
            IdentityServerId = contract.IdentityServerId,
        };
    }
}
