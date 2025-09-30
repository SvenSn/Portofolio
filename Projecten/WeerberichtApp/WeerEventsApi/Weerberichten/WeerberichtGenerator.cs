using WeerEventsApi.Metingen;

namespace WeerEventsApi.Weerberichten;

public class WeerberichtGenerator :IWeerberichtGenerator
{
    public Weerbericht GenerateWeerbericht(List<Meting> metingen)
    {
        Thread.Sleep(5000); // simuleren van wachten 

        string inhoud = $"Op basis van {metingen.Count} metingen metingen en mijn diepzinnig computermodel kan ik zeggen dat er kans is op {(IsGoedWeerOfSlecht(metingen) ? "Goed" : "Slecht")} weer.";

        return new Weerbericht(DateTime.Now, inhoud);
    }


    //methode om de te kijken of het weer goed of slecht is 
    private bool IsGoedWeerOfSlecht(List<Meting> metingen)
    {
        var temperatuurmetingen = metingen
            .Where(m => m.Eenheid == EenheidsType.GradenCelsius)
            .ToList();


        var luchtdrukmetingen = metingen
            .Where(m => m.Eenheid == EenheidsType.HectoPascal)
            .ToList();

        var neerslagmetingen = metingen
            .Where(m => m.Eenheid == EenheidsType.MillimeterPerVierkanteMeterPerUur)
            .ToList();

        var windsnelheidsmetingen = metingen
            .Where(m => m.Eenheid == EenheidsType.KMPerUur)
            .ToList();

        bool tempGoed = IsGemiddeldeTussen(temperatuurmetingen, 15, 30);
        bool luchtdrukGoed = IsGemiddeldeTussen(luchtdrukmetingen, 1010, 1025);
        bool neerslagGoed = IsGemiddeldeKleinerDan(neerslagmetingen, 0.5);
        bool windsnelheidGoed = IsGemiddeldeKleinerDan(windsnelheidsmetingen, 30);

        return tempGoed && luchtdrukGoed && neerslagGoed && windsnelheidGoed;
    }

    //gemiddelde berekenen van meegegeven metingen voor temperatuur en luchtdruk (tussen 2 waarden liggen)
    private bool IsGemiddeldeTussen(List<Meting> metingen, double min, double max)
    {
        if (metingen.Count == 0) return true;


        double som = 0;


        foreach (var m in metingen)
        {
            som += m.Waarde;
        }


        double gem = som / metingen.Count;


        return gem >= min && gem <= max;
    }


    //gemiddelde berekenen en bepalen of het kleiner dan de meegegeven max is bijvoorbeeld bij windsnelheid en neerslaag 
    private bool IsGemiddeldeKleinerDan(List<Meting> metingen, double max)
    {
        if (metingen.Count == 0) return true;


        double som = 0;


        foreach (var m in metingen)
        {
            som += m.Waarde;
        }


        double gem = som / metingen.Count;


        return gem < max;
    }
}
