namespace PartyFinder.Api.Contracts.ResponseContracts;

public record class MemberResponseContract(
    Guid id,
    string Username,
    string IdentityserverId,
    string AccountType,
    string MemberState
);
