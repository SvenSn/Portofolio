# WeerberichtApp

Een ASP.NET Core Web API in .NET 9 die weerstations en metingen modelleert en daar weerberichten uit genereert. Het project demonstreert verschillende ontwerp­patronen in een compacte domeintoepassing.

## Functionaliteit

- Steden uit JSON inladen en via de API ontsluiten.
- Temperatuur-, wind-, luchtdruk- en neerslagstations beheren.
- Metingen ontvangen en omzetten naar weerberichten.
- Logging uitbreiden met JSON- en XML-decorators.
- Observer-, factory-, decorator- en proxy-patterns toepassen.

## Structuur

- `Facade/` bevat controllers en DTO's.
- `Weerstations/`, `Metingen/`, `Steden/` en `Weerberichten/` bevatten het domein.
- `Logging/` bevat loggers, decorators, observers en factories.

## Starten

Vereist de .NET 9 SDK.

```powershell
dotnet restore .\WeerberichtApp.sln
dotnet run --project .\WeerEventsApi\WeerEventsApi.csproj
```

Gebruik `WeerEventsApi.http` of Swagger (wanneer ingeschakeld) om de endpoints lokaal te testen. Runtime-logbestanden zijn gegenereerde output en horen niet in Git.
