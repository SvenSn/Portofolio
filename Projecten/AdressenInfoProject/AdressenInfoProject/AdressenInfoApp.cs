using AdressenInfoProject.Domein;
using System;
using System.Linq;
using System.Runtime.Intrinsics.Arm;

namespace AdressenInfoProject;

public class AdressenInfoApp
{
    public void Run()
    {
        var adressen = BestandVerwerker.LeesAdressenUitBestand();
        GeefLijstProvincieNamenAlfabetischGesorteerd(adressen);

        Console.WriteLine("Geef een gemeente op om de straten in die gemeente te tonen:");
        string gemeente = "Gent";

        GeefLijstStratenOpgegevenGemeente(gemeente, adressen);

        Console.WriteLine("De meest voorkomende straat in de adressenlijst is:");
        GeefMeestVoorkomendeStraat(adressen);
        Console.WriteLine("Geef het aantal meest voorkomende straten dat je wilt zien:");
        int aantal = 5;


        Console.WriteLine($"De top {aantal} voorkomende straat in de adressenlijst is:");
        GeefDeTopAantalStraatnamenPerGemeente(aantal, adressen);


        Console.WriteLine("Geef twee gemeenten op om de gemeenschappelijke straten te tonen (gescheiden door een komma):");

        Console.WriteLine("======================================================================= \n");

        string gemeente1 = "Kortrijk";
        string gemeente2 = "Roeselare";
        GeefLijst2GemeentenGemeenschappelijkeStraten(adressen,gemeente1,gemeente2);


        Console.WriteLine("======================================================================= \n");
        Console.WriteLine("Geef gemeente in: ");
        string gemeentestraat = "Gent";

        GeefLijstStraatnamenEnkelVoorkomenGemeente(adressen, gemeentestraat);

        Console.WriteLine("======================================================================= \n");
        Console.WriteLine("De stad met de meeste straten: ");
        GeefGemeenteMetMeesteStraten(adressen);


        Console.WriteLine("======================================================================= \n");

        Console.WriteLine("De langste straatnaam:");
        GeefLangsteStraatnaam(adressen);


        Console.WriteLine("======================================================================= \n");

        Console.WriteLine("De gemeente met de langste straatnaam en provincie:");

        GeefLangsteStraatnaamMetProvincieEnGemeente(adressen);

        Console.WriteLine("======================================================================= \n");

        Console.WriteLine("Unieke straatnamen  :");
        GeefUniekeStraatnamen(adressen);

    }

    public void GeefLijstProvincieNamenAlfabetischGesorteerd(List<Adres> adressen)
    {
       var alfabetisch =  adressen
            .Select(a => a.Provincie)
            .Distinct()
            .OrderBy(p => p)
            .ToList();

        foreach (var provincie in alfabetisch)
        {
            Console.WriteLine(provincie);
        }
    }


    public void GeefLijstStratenOpgegevenGemeente(string gemeente,List<Adres> adressen)
    {
        var result = adressen
            .Where(a => a.Stad == gemeente)
            .Select(a => a.Straat)
            .ToList();

        foreach (var straat in result)
        {
            Console.WriteLine(straat);
        }
    }

    public void GeefMeestVoorkomendeStraat(List<Adres> adressen)
    {
        string meestVoorkomendeStraat = adressen
            .GroupBy(a => a.Straat)
            .OrderByDescending(g => g.Count())
            .First().Key;

        var result = adressen
            .Where(a => a.Straat == meestVoorkomendeStraat)
            .OrderBy(p => p.Provincie)
            .ThenBy(p => p.Stad);

        foreach (var adres in result)
        {
            Console.WriteLine($"{adres.Provincie}, {adres.Stad}, {adres.Straat}");
        }
    }

    public void GeefDeTopAantalStraatnamenPerGemeente(int aantal,List<Adres> adressen)
    {


        var topStraatnamen = adressen
             .GroupBy(a => a.Straat)
             .OrderByDescending(g => g.Count())
             .Take(aantal)
             .Select(g => g.Key)
             .ToHashSet();

        var result = adressen
            .Where(a => topStraatnamen.Contains(a.Straat))
            .OrderBy(p => p.Provincie)
            .ThenBy(p => p.Stad);

        foreach (var adres in result)
        {
            Console.WriteLine($"{adres.Provincie}, {adres.Stad}, {adres.Straat}");  
        }

    }

    public void GeefLijst2GemeentenGemeenschappelijkeStraten(List<Adres> adressen , string gemeente1,string gemeente2)
    {

        var stratenstad1 = adressen
            .Where(a => a.Stad == gemeente1)
            .Select(a => a.Straat)
            .Distinct();


        var stratenstad2 = adressen
            .Where(a => a.Stad == gemeente2)
            .Select(a => a.Straat)
            .Distinct();


        var result = stratenstad1.Intersect(stratenstad2);

        foreach (var straat in result)
        {
            Console.WriteLine(straat);
        }
    }

    public void GeefLijstStraatnamenEnkelVoorkomenGemeente(List<Adres> adressen, string gemeente)
    {
        var stratenGemeente = adressen
            .Where(a => a.Stad == gemeente)
            .Select(a => a.Straat)
            .Distinct();

        var stratenAlleGemeenten = adressen
            .Where(a => a.Stad != gemeente)
            .Select(a => a.Straat)
            .Distinct();    

        var result = stratenGemeente.Except(stratenAlleGemeenten);

        foreach (var straat in result)
        {
            Console.WriteLine(straat);
        }
    }

    public void GeefGemeenteMetMeesteStraten(List<Adres> adressen)
    {
        var stadmeestestraten = adressen
            .GroupBy(a => a.Stad)
            .Select(g => new
            {
                stad = g.Key,
                stratencount = g
                                .Select(a => a.Straat)
                                .Distinct()
                                .Count()
            })
            .OrderByDescending(a => a.stratencount)
            .FirstOrDefault()
            ?.stad;

        Console.WriteLine(stadmeestestraten);
    }

    public void GeefLangsteStraatnaam(List<Adres> adressen)
    {
        var straatnaam = adressen
            .OrderByDescending(a => a.Straat.Length)
            .Select(a => a.Straat)
            .First();

        Console.WriteLine(straatnaam);
    }

    public void GeefLangsteStraatnaamMetProvincieEnGemeente(List<Adres> adressen)
    {
        var straat = adressen
            .OrderByDescending(a => a.Straat.Length)
            .First();


        Console.WriteLine ($"De straat naam is {straat.Straat}, provincie : {straat.Provincie} en de gemeente : {straat.Stad}");
    }

    public void GeefUniekeStraatnamen(List<Adres> adressen)
    {
        var uniekestraten = adressen
            .DistinctBy(a => a.Straat)
            .ToList();


        uniekestraten.ForEach(a => Console.WriteLine($"{a.Provincie} , {a.Stad}, {a.Straat}"));
 
    }
}
