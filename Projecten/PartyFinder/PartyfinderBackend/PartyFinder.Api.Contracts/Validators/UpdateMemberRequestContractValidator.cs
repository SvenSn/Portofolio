using System;
using FluentValidation;
using PartyFinder.Api.Contracts.RequestContracts;

namespace PartyFinder.Api.Contracts.Validators;

public class UpdateMemberRequestContractValidator : AbstractValidator<UpdateMemberRequestContract>
{
    public UpdateMemberRequestContractValidator()
    {
        RuleFor(m => m.identityserverid)
            .NotEmpty()
            .Must(identityServerId => Guid.TryParse(identityServerId, out _))
            .WithMessage("Must be a valid identityserver guid");
        RuleFor(m => m.username)
            .MinimumLength(3)
            .MaximumLength(16)
            .NotEmpty()
            .WithMessage("Username must be atleast 3 characters long and maxiumum 16 characters.");
    }
}
