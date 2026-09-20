using Microsoft.AspNetCore.Mvc;
using PartyFinder.Api.Contracts.RequestContracts;
using Stripe;
using Stripe.Checkout;

[ApiController]
[Route("api/payments")]
public class PaymentsController : ControllerBase
{
    private readonly string _publishableKey;

    public PaymentsController(IConfiguration config)
    {
        _publishableKey = config["Stripe:PublishableKey"];
        Stripe.StripeConfiguration.ApiKey = config["Stripe:SecretKey"];
    }

    [HttpGet("config")]
    public IActionResult GetConfig()
    {
        return Ok(new { publishableKey = _publishableKey });
    }

    [HttpPost("create-payment-intent")]
    public IActionResult CreatePaymentIntent([FromBody] PaymentRequestContract request)
    {
        var service = new PaymentIntentService();
        var intent = service.Create(
            new PaymentIntentCreateOptions
            {
                Amount = request.Amount, // in cents
                Currency = request.Currency,
                PaymentMethodTypes = new List<string> { "card" },
            }
        );

        return Ok(new { clientSecret = intent.ClientSecret });
    }
}
