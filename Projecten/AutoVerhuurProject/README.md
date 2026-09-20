# AutoVerhuurProject

Een gelaagde .NET 9-applicatie voor het beheren van een autoverhuurbedrijf. De solution ondersteunt auto's, klanten, vestigingen en reserveringen, met zowel console- als WPF-presentatie en opslag via CSV of SQL Server.

## Functionaliteit

- Auto-, klant-, vestigings- en reserveringsgegevens beheren.
- CSV-gegevens importeren naar de database.
- Reserveringen aanmaken en raadplegen.
- Gegevens gebruiken via console-apps of een WPF-interface.
- Domeinregels afschermen achter managers, DTO's, factories en repositoryinterfaces.

## Architectuur

| Laag | Verantwoordelijkheid |
| --- | --- |
| `AutoVerhuurProject.Domein` | Modellen, DTO's, factories, managers en interfaces. |
| `Persistentielaag` | CSV-bestandsverwerking. |
| `Persistentielaag.Database` | SQL Server-repositories. |
| `Presentatielaag*` | Console- en WPF-gebruikersinterfaces. |
| `Domein.Tests` | Tests voor de belangrijkste domeinmodellen. |

## Starten en testen

Vereist .NET 9, Windows voor WPF en een bereikbare SQL Server wanneer je de databaselaag gebruikt.

```powershell
dotnet build .\AutoVerhuurProject.sln
dotnet test .\AutoVerhuurProject.Domein.Tests\AutoVerhuurProject.Domein.Tests.csproj
```

De oudere startup-projecten bevatten een lokale SQL Server-instancenaam. Pas die configuratie aan voor je eigen ontwikkelomgeving en commit nooit SQL-wachtwoorden.
