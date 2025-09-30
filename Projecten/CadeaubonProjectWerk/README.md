# CadeaubonProject

Een WPF-applicatie voor het aankopen en beheren van cadeaubonnen, ontwikkeld in het kader van het vak **Project 1** aan **HoGent**. De app laat toe om verschillende cadeaubonwaarden te selecteren, een thema te kiezen en een bestelling te plaatsen met doorgang naar betaling.


## 💻 Getting Started
### ✅ Vereisten

- Visual Studio 2022 of recenter
- .NET 9 SDK
- SQL Server Express (optioneel lokaal)
- Online SQL Server toegang (zie hieronder)
- Stripe API key (indien betaling geïntegreerd is)

### 📦 Installatie

1. Clone of download deze repository.
2. Open `CadeaubonProject.sln` in Visual Studio.
3. Herstel de NuGet-packages via **Build > Restore NuGet Packages**.
4. Stel het project in als **StartUp Project**: `Presentatielaag.Gui`.
5. Druk op **F5** om de app te starten.


## 🌐 Database

Deze applicatie gebruikt een **online SQL Server database**, met een hardcoded connection string in `App.xaml.cs`.

**Voorbeeld van de connectiestring**:

```csharp
Data Source=cigrit.fortiddns.com,11433;
Initial Catalog=Boomers25;
Persist Security Info=True;
User ID=Boomers25User;
Password=AVefhwNpvY5c6P;
Trust Server Certificate=True;
```

## 🚀 Functionaliteiten

- Selectie uit vaste bedragen (5€, 20€, 50€) of een zelfgekozen bedrag.
- Keuze van een cadeaubonthema zoals `Verjaardag`, `Kerst`, enz.
- Bestellingen worden aangemaakt en doorgestuurd naar een betaalpagina.
- Mogelijkheid tot integratie met Stripe voor online betaling.
- Overzicht van bestellingen beschikbaar via accountpagina.

## 🔧 Build & Run

1. Klik in Visual Studio op **Build > Build Solution**.
2. Start de app via **F5** of **Debug > Start Debugging**.
3. Zorg dat je internettoegang hebt voor de online database en eventueel Stripe.


## 🧪 Testen

Unit tests zijn opgenomen in het project `CadeaubonProject.Domein.Tests`.

Om de tests uit te voeren:
1. Open de **Test Explorer** in Visual Studio (menu **Test > Test Explorer**).
2. Klik op **Run All** of voer individuele tests uit.

Geteste componenten:
- Bestellingen
- Cadeaubonnen
- Klanten

Testframework: vermoedelijk xUnit of MSTest.

## 👥 Contributors

- Astrid Staessens  
- Sven Snoeck
