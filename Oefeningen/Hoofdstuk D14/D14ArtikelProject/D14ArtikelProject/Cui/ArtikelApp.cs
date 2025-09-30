using D14ArtikelProject.Domein;

namespace D14ArtikelProject.Cui
{
    public class ArtikelApp
    {
        public void Run()
        {
            Artikel a1 = new Artikel(1000.0,6);
            Console.WriteLine($"De prijs zonder btw bedraagt: {a1.PrijsExBTW},het btw % bedraagt: {a1.BTWPerentage}, de prijs inclusief btw: {a1.PrijsIncBTW()}");
            Artikel a2 = new Artikel(1000.0);
            Console.WriteLine($"De prijs zonder btw bedraagt: {a2.PrijsExBTW},het btw % bedraagt: {a2.BTWPerentage}, de prijs inclusief btw: {a2.PrijsIncBTW()}");
        }
    }
}
