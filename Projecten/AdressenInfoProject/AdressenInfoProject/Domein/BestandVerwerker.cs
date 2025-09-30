namespace AdressenInfoProject.Domein;

public class BestandVerwerker
{
    const string bestandNaam = @"C:\Users\Complex\Documents\GitHubProg\Programmeren\ProgGov\Portifolio\AdressenInfoProject\Data\adresInfo.txt";  


    public static List<Adres> LeesAdressenUitBestand()
    {
        var adressen = new List<Adres>();
        
        if (!File.Exists(bestandNaam))
        {
            throw new FileNotFoundException($"Het bestand {bestandNaam} bestaat niet.");
        }
        var regels = File.ReadAllLines(bestandNaam);
        
        foreach (var regel in regels)
        {
            var delen = regel.Split(',');
            adressen.Add(new Adres(delen[0].Trim(), delen[1].Trim(), delen[2].Trim())); 
        }
        return adressen;
    }
}
