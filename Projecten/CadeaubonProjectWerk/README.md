# CadeaubonProject

Een WPF-applicatie in .NET 9 voor het aankopen, beheren en verzilveren van cadeaubonnen. Het project is opgebouwd uit domein-, persistentie-, test- en presentatielagen.

## Functionaliteit

- Klanten registreren en aanmelden.
- Een vast of vrij cadeaubonbedrag kiezen.
- Een thema selecteren, zoals verjaardag of kerst.
- Bestellingen samenstellen en de betaalflow openen.
- Bestellingen en cadeaubonnen via een accountpagina beheren.
- Cadeaubonnen verzilveren.

## Technologie en structuur

- WPF en XAML voor de desktopinterface.
- SQL Server en repository-implementaties voor opslag.
- Managers, DTO's en factories in de domeinlaag.
- Stripe-integratie voor betalingen.
- Unit tests voor klanten, bestellingen en cadeaubonnen.

## Lokale configuratie

Vereist Visual Studio 2022 of recenter, de .NET 9 SDK en een SQL Server-database. De databaseverbinding staat bewust niet in Git. Stel ze lokaal in voordat je de app start:

```powershell
$env:CADEAUBON_DB_CONNECTION_STRING = "Server=...;Database=...;User Id=...;Password=...;TrustServerCertificate=True"
```

Plaats Stripe-sleutels evenmin in broncode. Gebruik voor lokale ontwikkeling user secrets of environmentvariabelen en vul geen echte waarden in een te committen `appsettings.json` in.

## Bouwen en testen

```powershell
dotnet build .\CadeaubonProject\CadeaubonProject.sln
dotnet test .\CadeaubonProject\CadeaubonProject.Domein.Tests\CadeaubonProject.Domein.Tests.csproj
```

Stel `CadeaubonProjectWerk.Presentatielaag.Gui` in als opstartproject om de WPF-app via Visual Studio te starten.

## Beveiliging

Een eerder gecommitteerd databasewachtwoord moet worden ingetrokken en vervangen. Alleen het verwijderen uit de huidige bestanden haalt een geheim niet uit de Git-geschiedenis.
