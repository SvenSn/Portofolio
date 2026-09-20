# AdressenInfoProject

Een .NET 9-consoleapp die adresgegevens uit een tekstbestand inleest en met LINQ analyseert. Het project toont bestandsverwerking, modellering, groepering, sortering en setbewerkingen.

## Functionaliteit

- Provincies alfabetisch en zonder dubbels tonen.
- Straten per gemeente opzoeken.
- De meest voorkomende en langste straatnamen bepalen.
- Gemeenschappelijke of unieke straatnamen tussen gemeenten vergelijken.
- De gemeente met de meeste verschillende straten vinden.

## Structuur

- `AdressenInfoApp.cs` bevat de analyses en console-uitvoer.
- `Domein/Adres.cs` modelleert één adresregel.
- `Domein/BestandVerwerker.cs` leest `Data/adresInfo.txt`.

## Starten

Vereist de .NET 9 SDK.

```powershell
dotnet run --project .\AdressenInfoProject\AdressenInfoProject.csproj
```

Het meegeleverde `Data/adresInfo.txt` wordt bij het bouwen automatisch naar de outputmap gekopieerd.
