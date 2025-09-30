using D15artikelProject.Domein;

namespace D15artikelProject.CUI
{
    public class ArtikelApp
    {
        public void Run()
        {
            Artikel a1 = new Artikel();
            Console.WriteLine(a1.BTWpercentage == 21);


            a1.PrijsExBTW = 1000m;
            a1.BTWpercentage = 6m;

            Console.WriteLine(a1.PrijsExBTW == 1000m);
            Console.WriteLine(a1.BTWpercentage == 6m);
            Console.WriteLine(a1.PrijsIncBTW() == 1060m);
        }
    }
}
