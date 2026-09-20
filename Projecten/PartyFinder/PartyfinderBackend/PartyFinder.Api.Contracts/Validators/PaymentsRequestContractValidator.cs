using System;
using FluentValidation;
using PartyFinder.Api.Contracts.RequestContracts;

namespace PartyFinder.Api.Contracts.Validators;

public class PaymentsRequestContractValidator : AbstractValidator<PaymentRequestContract>
{
    public PaymentsRequestContractValidator()
    {
        RuleFor(p => p.Currency)
            .NotEmpty()
            .Must(currency => new[] { "eur", "gbp", "usd" }.Contains(currency?.ToLower()))
            .WithMessage("Currency must be one of: eur, gbp, usd.");

        RuleFor(p => p.Amount)
            .GreaterThanOrEqualTo(100)
            .WithMessage("Donate at least 1 of the corresponding currencies");
    }
}
