using System;

namespace PartyFinder.Api.Contracts.RequestContracts;

public record PaymentRequestContract(long Amount, string Currency);
