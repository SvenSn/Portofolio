using D15artikelmetprijsProject.Domein;

namespace D15artikelmetprijsProject.CUI
{
    public class ArtikelApp
    {
        public void Run()
        {
            Artikel artikel1 = new Artikel(100m);
            Console.WriteLine(artikel1.PrijsExBTW == 100m);    // zou true moeten opleveren
            Console.WriteLine(artikel1.BTWpercentage == 21m);         // zou true moeten opleveren
            Console.WriteLine(artikel1.PrijsIncBTW() == 121m);  // zou true moeten opleveren

            // Test of de __setters__ nog correct functioneren:
            artikel1.PrijsExBTW = 1000m;
            artikel1.BTWpercentage = 6m;
            Console.WriteLine(artikel1.PrijsExBTW == 1000m);   // zou true moeten opleveren
            Console.WriteLine(artikel1.BTWpercentage == 6m);          // zou true moeten opleveren
            Console.WriteLine(artikel1.PrijsIncBTW() == 1060m); // zou true moeten opleveren

            // Test de constructor met twee parameters:
            Artikel artikel2 = new Artikel(200m, 6m);
            Console.WriteLine(artikel2.PrijsExBTW == 200m);    // zou true moeten opleveren
            Console.WriteLine(artikel2.BTWpercentage == 6m);          // zou true moeten opleveren
            Console.WriteLine(artikel2.PrijsIncBTW() == 212m);
        }
    }
}
