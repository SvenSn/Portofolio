# Portfolio

Een monorepo met grotere applicatieprojecten en C#-oefeningen. De projecten tonen ervaring met .NET, WPF, .NET MAUI, ASP.NET Core, React, React Native, Expo, databases, authenticatie en geautomatiseerde tests.

## Inhoud

- [`Projecten/`](Projecten/README.md) bevat de uitgewerkte portfolio-applicaties.
- [`Oefeningen/`](Oefeningen/README.md) bevat kleinere leer- en herhalingsoefeningen in C#.

## Uitgelichte projecten

| Project | Technologie | Omschrijving |
| --- | --- | --- |
| [BudgetApp](Projecten/BudgettingApp/README.md) | .NET MAUI, EF Core, SQLite | Mobiele en desktopapp voor rekeningen, budgetten, transacties en spaardoelen. |
| [PartyFinder](Projecten/PartyFinder/README.md) | ASP.NET Core, IdentityServer, React | Full-stack platform voor matchmaking en partyvorming. |
| [PetSteps](Projecten/PetSteps/README.md) | React Native, Expo, Firebase | Stappenteller waarin beweging de voortgang van virtuele huisdieren bepaalt. |
| [SamenSterk](Projecten/SamenSterk/README.md) | React Native, Expo, Firebase | Toegankelijke oefen- en puzzelapp met planning en beheermogelijkheden. |
| [AutoVerhuur](Projecten/AutoVerhuurProject/README.md) | .NET, WPF, SQL Server | Gelaagde applicatie voor auto's, klanten, vestigingen en reserveringen. |
| [CadeaubonProject](Projecten/CadeaubonProjectWerk/README.md) | .NET, WPF, SQL Server | Cadeaubonnen bestellen, beheren en verzilveren. |
| [WeerberichtApp](Projecten/WeerberichtApp/README.md) | ASP.NET Core | Weer-API met stations, metingen, logging en ontwerp­patronen. |
| [AdressenInfo](Projecten/AdressenInfoProject/README.md) | .NET console, LINQ | Analyse van gemeenten, provincies en straatnamen uit een tekstbestand. |

## Repository gebruiken

Clone de repository en open daarna de solution of projectmap die je wilt uitvoeren. De benodigde SDK, configuratie en startcommando's staan in de README van elk project.

Gegenereerde bestanden horen niet in Git. De centrale [`.gitignore`](.gitignore) dekt Visual Studio/VS Code, .NET, Node.js, React, Expo, React Native, Android, iOS, lokale databases, logs en geheimen. Plaats echte sleutels en wachtwoorden alleen in lokale environmentvariabelen of genegeerde `.env`-bestanden.

## Let op

Dit is een leer- en portfoliorepository. Niet elk ouder oefenproject is bedoeld als productiecode en sommige applicaties vereisen een lokale database of externe dienst. Deel nooit productiegegevens, privésleutels of persoonlijke data via commits.
