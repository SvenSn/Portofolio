# PartyFinder backend

De backend bestaat uit een ASP.NET Core Web API, een Duende IdentityServer-host, domeinservices, persistence, contracten en tests.

## Projecten

| Project | Rol |
| --- | --- |
| `PartyFinder.Api` | REST-endpoints, authorisatie, SignalR en Stripe-betalingen. |
| `PartyFinder.Api.Contracts` | Request-/responsecontracten en validatie. |
| `PartyFinder.Domain.Services` | Lobby-, matchmaking-, member- en hiscorelogica. |
| `PartyFinder.Persistence*` | Entity Framework Core, repositories en entiteiten. |
| `PartyFinder.IdentityServer` | Gebruikers, rollen en OIDC/OAuth2. |
| `PartyFinder.Tests` | Geautomatiseerde tests. |

## Configuratie

Gebruik ASP.NET Core-environmentvariabelen of user secrets. Voorbeelden:

```powershell
$env:ConnectionStrings__PartyFinderDb = "..."
$env:ConnectionStrings__PartyFinderDbIdentityserver = "..."
$env:Stripe__SecretKey = "..."
$env:Stripe__PublishableKey = "..."
$env:PARTYFINDER_POSTMAN_CLIENT_SECRET = "REDACTED"
```

## Bouwen en testen

Vereist .NET 9; IdentityServer target momenteel .NET 8.

```powershell
dotnet restore .\PartyFinder.sln
dotnet build .\PartyFinder.sln
dotnet test .\PartyFinder.Tests\PartyFinder.Tests.csproj
dotnet run --project .\PartyFinder.IdentityServer\PartyFinder.IdentityServer.csproj
dotnet run --project .\PartyFinder.Api\PartyFinder.Api.csproj
```

Configureer databases en voer de aanwezige EF Core-migraties uit voordat je de volledige applicatie gebruikt.
