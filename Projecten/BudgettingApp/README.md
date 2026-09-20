# BudgetApp

Choose your language / Kies je taal:

- [English README](README.en.md)
- [Nederlandse README](README.nl.md)

The complete project documentation is available in both languages.

Een budgetapp in **C# 14 en .NET 10 MAUI** voor het beheren van rekeningen, inkomsten, uitgaven, budgetten en spaardoelen.

De app gebruikt een lokale SQLite-database en één actieve rekening voor alle financiële schermen. De interface is beschikbaar in Nederlands en Engels, met een licht en donker thema.

## Status en platformen

Het project is in ontwikkeling.

- **Windows x64:** Release-publicatie beschikbaar als losse appmap met EXE.
- **Android:** Release-test-APK beschikbaar, ondertekend met een ontwikkelsleutel.
- **iOS en Mac Catalyst:** opgenomen als projecttargets, maar niet geverifieerd voor deze publicatie.

De Windows- en Android-publicaties zijn gebouwd. De Android-ondertekening is gecontroleerd. Dit is geen vervanging voor functionele tests op echte toestellen.

## Functionaliteiten

- Eerste rekening aanmaken wanneer er nog geen rekeningen bestaan.
- Meerdere rekeningen beheren, inclusief rekeningtype en beginsaldo.
- Eén actieve rekening selecteren; de selectie blijft bewaard na herstarten.
- Dashboard met rekeningsaldo, maandresultaat, inkomsten en uitgaven.
- Taartdiagram met uitgavencategorieën en eventueel het resterende bedrag.
- Transacties toevoegen, bewerken en verwijderen.
- Inkomen vastleggen met een ingangsdatum.
- Budgetten instellen per categorie en maand.
- Spaardoelen aanmaken, bewerken, verwijderen en voortgang bijhouden.
- Historiek en details per maand bekijken.
- Nederlandse en Engelse interface, met gelokaliseerde enumlabels.
- Datums en getalnotatie volgens de toestelinstellingen.

Het rekeningoverzicht toont alle rekeningen. De financiële schermen tonen de gegevens van de **actieve rekening**. Taal en thema zijn instellingen voor de hele app.

## Belangrijk: saldo is niet hetzelfde als inkomen

| Onderdeel | Betekenis |
| --- | --- |
| Rekeningsaldo | Beginsaldo, aangepast door geboekte inkomsten- en uitgaventransacties. |
| Ingesteld inkomen | Bedrag met een ingangsdatum; maakt geen rekeningtransactie aan. |
| Maandresultaat | Geldig ingesteld inkomen plus geboekte inkomstentransacties, min uitgaven van de maand. |
| Spaardoelbijdrage | Registratie van voortgang; verplaatst geen geld tussen rekeningen. |

Als hetzelfde loon zowel als ingesteld inkomen als inkomstentransactie wordt ingevoerd, telt het dashboard beide mee in het maandoverzicht. Dit is de huidige berekeningswijze.

## Technische stack

- C# 14 en .NET 10
- .NET MAUI, XAML en Shell-navigatie
- CommunityToolkit.Mvvm
- Entity Framework Core met SQLite
- Dependency injection
- Font Awesome voor navigatie-iconen
- xUnit voor geautomatiseerde tests

## Projectstructuur

| Project | Verantwoordelijkheid |
| --- | --- |
| `BudgetApp.App` | MAUI-views, viewmodels, navigatie, lokalisatie, styling en dependency injection. |
| `BudgetApp.Domain` | Entiteiten, enums, service- en repositoryinterfaces en bedrijfslogica. |
| `BudgetApp.Infrastructure` | EF Core-context, SQLite-configuratie, database-initialisatie en repositoryimplementaties. |
| `BudgetApp.Tests` | Tests voor onder meer rekeningisolatie, opslag, saldo-effecten, schema-upgrades en lokalisatie. |

Aanvullende documentatie staat in [docs/distribution](docs/distribution). Lokale publicatiebestanden staan onder `publish/` en worden niet als broncode beheerd.

### MVVM en dependency injection

- **Views (`.xaml`)** beschrijven de interface en databindings.
- **Code-behind (`.xaml.cs`)** koppelt de view aan het viewmodel en verzorgt de paginalevenscyclus.
- **Viewmodels** bieden bindbare properties en commands aan.
- **Services** voeren applicatie- en domeinbewerkingen uit.
- **Repositories** lezen en schrijven gegevens.

De registraties staan in [MauiProgram.cs](BudgetApp.App/MauiProgram.cs). Services, repositories, pagina's en viewmodels worden als transient geregistreerd.

Repositories gebruiken `IDbContextFactory<BudgetDbContext>`: iedere repositorybewerking maakt een eigen context en ruimt die na gebruik op. Er wordt geen databasecontext gedurende de volledige levensduur van de app gedeeld.

[ActiveAccountState](BudgetApp.App/Services/ActiveAccountState.cs) is een singleton die de rekeningkeuze deelt. [AccountPageController](BudgetApp.App/Controls/AccountPageController.cs) verzorgt de rekeningkiezer en het herladen van de zichtbare pagina.

## Lokaal ontwikkelen

### Benodigdheden

- .NET 10 SDK.
- Visual Studio met ondersteuning voor .NET 10 MAUI en de MAUI-workload.
- Voor Windows: de benodigde Windows SDK.
- Voor Android: Android SDK, bijbehorende JDK en een emulator of geschikt fysiek toestel.

De SDK-versie is momenteel niet vastgezet met een `global.json`.

### Starten via Visual Studio

1. Open `BudgetApp.sln`.
2. Stel `BudgetApp.App` in als opstartproject.
3. Laat de NuGet-packages herstellen.
4. Kies **Windows Machine** of een Android-emulator/toestel.
5. Start met **F5**.

Gebruik bij een nieuwe installatie eerst het scherm om een rekening aan te maken. Een rekening is hier een financiële rekening, geen persoonlijk loginaccount.

### Bouwen via PowerShell

Voer de volgende commando's uit vanuit de hoofdmap van de repository.

Windows:

```powershell
dotnet build .\BudgetApp.App\BudgetApp.App.csproj -f net10.0-windows10.0.19041.0 -c Debug
```

Android:

```powershell
dotnet build .\BudgetApp.App\BudgetApp.App.csproj -f net10.0-android -c Debug
```

Deze commando's bouwen de app; gebruik Visual Studio om een toestel te kiezen en de app te starten.

## Tests uitvoeren

```powershell
dotnet test .\BudgetApp.Tests\BudgetApp.Tests.csproj
```

De databasetests gebruiken tijdelijke SQLite-databases in het geheugen, niet je lokale appdatabase.

De tests controleren onder andere:

- Scheiding van gegevens tussen rekeningen.
- Saldo-effecten van transacties.
- Spaardoelen bewerken en verwijderen.
- Maandtotalen en uitgavencategorieën.
- Behoud van oude gegevens bij schema-upgrades.
- Lokalisatie en formattering.

Test publicatiebuilds daarnaast op een toestel: een geslaagde build of unit-test controleert niet de volledige interface of het platformgedrag.

## Database en gegevensbehoud

De database heet `budgetapp.db` en staat in `FileSystem.AppDataDirectory`. De precieze locatie wordt bepaald door het platform.

[DatabaseInitializer](BudgetApp.Infrastructure/Data/DatabaseInitializer.cs) maakt een nieuwe database aan met `EnsureCreated()` en vult voor bestaande databases de rekeningkoppelingen aan voor inkomen, budgetten en spaardoelen.

Bestaande records zonder rekening blijven **ongekoppeld**. Via **Nog te koppelen** kiest de gebruiker zelf bij welke rekening ze horen. Tot die tijd tellen ze niet mee in de rekeningtotalen.

Dit project gebruikt momenteel gerichte schema-upgrades, geen volledig ingerichte EF Core-migratieworkflow. Nieuwe schemawijzigingen vereisen daarom een expliciet upgradepad en bijbehorende tests. Alleen `EnsureCreated()` aanroepen werkt een bestaande databasestructuur niet bij.

### Waarschuwingen

- Een rekening verwijderen verwijdert ook de gekoppelde transacties, inkomens, budgetten en spaardoelen, na bevestiging.
- Appopslag wissen of de Android-app verwijderen kan lokale gegevens verwijderen.
- Er is geen ingebouwde synchronisatie tussen Windows en Android.
- Een publicatie-ZIP is geen back-up van de appdatabase.
- Maak een databaseback-up terwijl de app gesloten is; bewaar eventueel aanwezige bijbehorende SQLite-bestanden mee.

## Publiceren

Publiceer het MAUI-project, niet de volledige solution.

### Windows x64

```powershell
dotnet publish .\BudgetApp.App\BudgetApp.App.csproj `
    -f net10.0-windows10.0.19041.0 `
    -c Release `
    -p:RuntimeIdentifierOverride=win-x64 `
    -p:WindowsPackageType=None `
    -p:SelfContained=true `
    -p:WindowsAppSDKSelfContained=true `
    -o .\publish\windows
```

Start daarna `publish/windows/BudgetApp.App.exe`. Verspreid de **volledige map**, niet alleen de EXE. De runtimecomponenten worden meegeleverd.

Gebruikershandleiding: [Windows README](docs/distribution/README-Windows.md).

### Android-test-APK

```powershell
dotnet publish .\BudgetApp.App\BudgetApp.App.csproj `
    -f net10.0-android `
    -c Release `
    -p:AndroidPackageFormats=apk `
    -p:AndroidKeyStore=false `
    -o .\publish\android-test
```

Gebruik `com.companyname.budgetapp.app-Signed.apk` uit die map.

**Dit commando gebruikt de lokale ontwikkelsleutel.** Voor definitieve distributie is een eigen keystore nodig. Bewaar sleutels en wachtwoorden veilig buiten Git, gebruik bij updates dezelfde ondertekeningssleutel en verhoog `ApplicationVersion`.

Een installatie met een andere ondertekeningssleutel kan niet zomaar worden bijgewerkt. Verwijder de oude app niet zonder eerst de gegevens veilig te stellen.

Gebruikershandleiding: [Android README](docs/distribution/README-Android.md).

## Styling en vertalingen aanpassen

- Gedeelde styles: [Resources/Styles/Styles.xaml](BudgetApp.App/Resources/Styles/Styles.xaml).
- Engelse teksten: [AppStrings.resx](BudgetApp.App/Resources/Strings/AppStrings.resx).
- Nederlandse teksten: [AppStrings.nl.resx](BudgetApp.App/Resources/Strings/AppStrings.nl.resx).
- Vertaalhulpmiddelen en enumweergave: [Localization](BudgetApp.App/Localization).
- Lettertypen en iconen: [Resources/Fonts](BudgetApp.App/Resources/Fonts).

Voeg nieuwe tekstsleutels in beide talen toe. Verander de toestelcultuur niet om de interfacetaal te wijzigen: datums en getallen moeten de toestelinstellingen blijven volgen.

## Problemen melden

Beschrijf het platform, de appversie, de stappen om het probleem te reproduceren en de volledige foutmelding. Vermeld bij onverwachte bedragen ook de actieve rekening, maand en het verschil tussen ingesteld inkomen en geboekte transacties.

Deel geen wachtwoorden, keystores of persoonlijke financiële gegevens in een issue.
