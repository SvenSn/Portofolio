# BudgetApp voor Windows

Beheer je rekeningen, transacties, inkomen, budgetten en spaardoelen op één plek.

Deze uitgave is een **Windows x64-testpublicatie**. De app is gebouwd in Release-modus, maar deze publicatie is nog niet op een toestel getest.

## Installeren en starten

1. Download of kopieer `BudgetApp-windows-x64.zip` naar je computer.
2. Pak de ZIP **volledig uit** naar een eigen map.
3. Open de uitgepakte map en start `BudgetApp.App.exe`.

Start de app niet rechtstreeks vanuit de ZIP. Verplaats niet alleen de EXE: de andere bestanden en submappen zijn ook nodig.

Dit is een losse appmap, geen installatieprogramma. De .NET- en Windows App SDK-runtime zijn inbegrepen; Visual Studio is niet nodig.

## Eerste gebruik

1. Maak je eerste rekening aan met een naam, rekeningtype en beginsaldo.
2. Kies bovenaan een financiële pagina je **actieve rekening**.
3. Voeg transacties toe voor die rekening.
4. Stel eventueel inkomen, budgetten en spaardoelen in.

De actieve rekening geldt voor het dashboard, de grafiek, transacties, inkomen, budgetten, spaardoelen en historiek. Je keuze blijft bewaard na herstarten. Het rekeningoverzicht toont alle rekeningen om ze te beheren.

Bestaande inkomens, budgetten en spaardoelen zonder rekeningkoppeling staan onder **Nog te koppelen**. Ze tellen pas mee voor een rekening nadat je ze daaraan koppelt.

## Saldo en inkomen: het verschil

- **Rekeningsaldo:** het beginsaldo, aangepast door geboekte inkomsten- en uitgaventransacties.
- **Ingesteld inkomen:** een maandelijks bedrag met een ingangsdatum. Het wordt op dezelfde dag van elke maand als inkomenstransactie geboekt en verhoogt dan het saldo.
- **Maandresultaat:** geboekte inkomstentransacties min de uitgaventransacties van die maand.
- **Spaardoelbijdrage:** houdt je voortgang bij; verplaatst geen geld tussen rekeningen.

De app voorkomt dubbele automatische boekingen per maand. De automatische boeking gebeurt zodra de app op of na de betaaldag wordt geopend.

## Taal en weergave

In **Instellingen** kun je Nederlands of Engels kiezen en de lichte of donkere weergave instellen. Datums en getalnotatie volgen de toestelinstellingen.

## Gegevens en updates

De app bewaart je gegevens lokaal in een SQLite-database, `budgetapp.db`, in de appgegevensmap. De publicatiemap bevat de programmabestanden, niet automatisch een back-up van je gegevens. Reken niet op synchronisatie tussen Windows en Android.

Voor een update:

1. Sluit de app.
2. Bewaar een back-up van je bestaande gegevens voordat je een testupdate gebruikt.
3. Pak de nieuwe publicatie uit naar een aparte map en gebruik de volledige nieuwe versie.

Maak een databaseback-up alleen terwijl de app gesloten is en bewaar eventueel aanwezige bijbehorende SQLite-bestanden mee. Verwijder of overschrijf de appgegevensmap niet.

**Een rekening verwijderen verwijdert ook de gekoppelde transacties, inkomens, budgetten en spaardoelen.** De app vraagt hiervoor bevestiging. Er is geen prullenbak voor deze actie.

## Problemen oplossen

**De app start niet of meldt ontbrekende bestanden**  
Pak de volledige ZIP opnieuw uit. Controleer dat je de Windows x64-uitgave gebruikt en niet alleen de EXE hebt gekopieerd.

**Windows toont een beveiligingswaarschuwing**  
Controleer eerst van wie je het bestand hebt ontvangen. Schakel beveiligingssoftware niet uit om een onbekend bestand te starten.

**Ik zie geen gegevens**  
Controleer de actieve rekening, de geselecteerde maand, de ingangsdatum van je inkomen en eventuele items onder Nog te koppelen. Gebruik daarna Vernieuwen.

**Het saldo komt niet overeen met het ingestelde inkomen**  
Controleer of de betaaldag al bereikt is en of de app daarna minstens één keer is geopend.

## Een probleem melden

Vermeld je Windows-versie, de appversie, de uitgevoerde stappen en de volledige foutmelding. Voeg eventueel een screenshot toe zonder persoonlijke financiële gegevens. Deel geen database of andere gevoelige bestanden zomaar.
