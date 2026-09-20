using System;
using FluentValidation;
using FluentValidation.AspNetCore;
using PartyFinder.Api.Contracts.RequestContracts;

namespace PartyFinder.Api.Contracts.Validators;

public class QueueRequestContractValidator : AbstractValidator<QueueRequestContract>
{
    public QueueRequestContractValidator()
    {
        RuleFor(q => q.PreLobbyId)
            .NotEmpty()
            .Must(id => id != Guid.Empty)
            .WithMessage("Must be a valid prelobbyId Guid");
    }
}
