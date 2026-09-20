using System.Text.Json.Serialization;
using Azure.Identity;
using Azure.Storage.Blobs;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using PartyFinder.Api.Contracts.Validators;
using PartyFinder.Domain.Services;
using PartyFinder.Domain.Services.Hubs;
using PartyFinder.Domain.Services.Interfaces;
using PartyFinder.Persistence;
using PartyFinder.Persistence.Entities;
using PartyFinder.Persistence.Interfaces;
using PartyFinder.Persistence.Repositories;
using Scalar.AspNetCore;
using ShipIt.PriceQuote.Api;

var builder = WebApplication.CreateBuilder(args);

//keyvault
builder.Configuration.AddAzureKeyVault(
    new Uri("https://raidlesspg3-keyvault.vault.azure.net/"),
    new DefaultAzureCredential()
);

//stripe
var stripeSection = builder.Configuration.GetSection("Stripe");
Stripe.StripeConfiguration.ApiKey = stripeSection["SecretKey"];

// Add services to the container.
builder.Services.AddHttpContextAccessor();
builder.Services.AddSingleton<IAuthorizationHandler, PartyfinderAuthHandler>();

// PartyFinder DbContext
builder.Services.AddDbContext<PartyFinderDBContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("PartyFinderDb"))
);

// ...existing code...

//httpclient
builder.Services.AddHttpClient<IOsrsHiScoresService, OsrsHiscoresService>();
builder.Services.AddSingleton<IUserIdProvider, SubUserIdProvider>();

//repositories
builder.Services.AddScoped<IMemberRepository, MemberRepository>();
builder.Services.AddScoped<IPreLobbyRepository, PreLobbyRepository>();
builder.Services.AddScoped<IQueuePartyRepository, QueuePartyRepository>();
builder.Services.AddScoped<ILobbyRepository, LobbyRepository>();

// Unit of Work
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

//blob
builder.Services.AddSingleton<BlobServiceClient>(sp => new BlobServiceClient(
    builder.Configuration["Blobstorage"]
));

// Domain Services
builder.Services.AddScoped<IBlobStorageService, BlobStorageService>();
builder.Services.AddScoped<IMemberService, MemberService>();
builder.Services.AddScoped<IPreLobbyService, PreLobbyService>();
builder.Services.AddScoped<IQuePartyService, QueuePartyService>();
builder.Services.AddScoped<ILobbyService, LobbyService>();

//hosted services
builder.Services.AddHostedService<MatchmakingService>();

// SignalR
builder.Services.AddSignalR(options =>
{
    options.ClientTimeoutInterval = TimeSpan.FromHours(24);
    options.HandshakeTimeout = TimeSpan.FromHours(30);
    options.KeepAliveInterval = TimeSpan.FromMinutes(2);
});
builder.Services.AddFluentValidationAutoValidation();
builder.Services.AddValidatorsFromAssemblyContaining<MemberRequestContractValidator>();

builder
    .Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
    });
builder.Services.AddOpenApi();

builder
    .Services.AddAuthentication(options =>
    {
        options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
        options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    })
    .AddJwtBearer(options =>
    {
        options.Authority =
            "https://hogent-partyfinderidentityserver-svensnoeck-b3e3dfbfd6dufjbk.northeurope-01.azurewebsites.net";
        options.Audience =
            "https://hogent-partyfinderidentityserver-svensnoeck-b3e3dfbfd6dufjbk.northeurope-01.azurewebsites.net/resources";
        options.MapInboundClaims = false;
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateAudience = true,
            ValidAudience =
                "https://hogent-partyfinderidentityserver-svensnoeck-b3e3dfbfd6dufjbk.northeurope-01.azurewebsites.net/resources",
            NameClaimType = "sub",
            RoleClaimType = "role",
        };
        options.Events = new JwtBearerEvents
        {
            OnMessageReceived = context =>
            {
                var accessToken = context.Request.Query["access_token"];
                var path = context.HttpContext.Request.Path;
                if (
                    !string.IsNullOrEmpty(accessToken)
                    && (
                        path.StartsWithSegments("/hubs/prelobby")
                        || path.StartsWithSegments("/hubs/lobby")
                    )
                )
                {
                    context.Token = accessToken;
                }
                return Task.CompletedTask;
            },
        };
    });

builder
    .Services.AddAuthorizationBuilder()
    .AddPolicy(
        "UserOrAdminPartyFinderReadWritePolicy",
        policy =>
        {
            policy.AddRequirements(
                new ClaimOrRoleRequirement("partyfinder.api.Read", "User", "Admin")
            );
            policy.AddRequirements(
                new ClaimOrRoleRequirement("partyfinder.api.Write", "User", "Admin")
            );
        }
    )
    .AddPolicy(
        "AdminPartyFinderReadWritePolicy",
        policy =>
        {
            policy.AddRequirements(new ClaimOrRoleRequirement("partyfinder.api.Read", "Admin"));
            policy.AddRequirements(new ClaimOrRoleRequirement("partyfinder.api.Write", "Admin"));
        }
    );

builder.Services.AddCors(options =>
{
    options.AddPolicy(
        "RaidlessFrontend",
        policy =>
            policy
                .WithOrigins(
                    "https://hogent-partyfinderfrontend-svensnoeck-efcjbsenduhye5h7.northeurope-01.azurewebsites.net"
                )
                .AllowAnyHeader()
                .AllowAnyMethod()
                .AllowCredentials()
    );
});
builder.Services.AddEndpointsApiExplorer();
var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();
app.UseRouting();
app.UseCors("RaidlessFrontend");
app.UseAuthentication();
app.UseAuthorization();

//scalar
app.MapScalarApiReference(options =>
{
    options.WithOpenApiRoutePattern("/openapi/v1.json");
});

//mapping hub
app.MapHub<PreLobbyHub>("/hubs/prelobby");
app.MapHub<LobbyHub>("/hubs/lobby");
app.MapControllers();

app.Run();
