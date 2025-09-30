using System.Runtime.Intrinsics.Arm;
using WinkelKarproject.Domein;

namespace WinkelKarproject.CUI
{
    internal class WinkelkarApp
    {
        private WinkelKar _winkelkar = new WinkelKar();

        public void Run()
        {
            List<Product> producten = new List<Product>{
            new VoedingsProduct("Campina halfvolle melk 1L", 1.05M, Nutriscore.B),
            new NietVoedingsProduct("Koffiezet Philips", 34.99M, 10),
            new VoedingsProduct("Lu cracotte volkoren 250g", 1.65M, Nutriscore.C),
            new VoedingsProduct("Nutella choco 975g", 5.00M, Nutriscore.E),
            new NietVoedingsProduct("Broodrooster Philips", 29.99M, 20)
        };
            producten.Sort();


            int keuze, aantalStuks = 0;
            do
            {
                keuze = MaakKeuzeUitProducten("Kies een product om in de winkelkar te plaatsen: ", producten, "Einde boodschappen");
                if (keuze == 0)
                    break;
                while (true)
                {
                    aantalStuks = GeefStriktPositiefGetal("Geef het aantal stuks: ");
                    if (aantalStuks > 0)
                        break;
                    Console.WriteLine("Getal moet strikt positief zijn!");
                }
                _winkelkar.VoegToeAanBoodschappen(producten[keuze - 1], aantalStuks);
            } while (true);

            if (_winkelkar.GeefBeschrijvingPerBoodschap().Count == 0)
                Console.WriteLine("Geen aankopen verricht!");
            else
            {
                Console.WriteLine("Overzicht boodschappen: ");
                Console.WriteLine(String.Join("\n", _winkelkar.GeefBeschrijvingPerBoodschap()));
                Console.WriteLine($"Totale kostprijs zonder korting: {_winkelkar.BerekenTotalePrijsZonderKorting(),0:F2} euro.");
                Console.WriteLine($"Totale kostprijs met korting: {_winkelkar.BerekenTotalePrijsMetKorting(),0:F2} euro.");
            }
        }

        private int MaakKeuzeUitProducten(string titel, List<Product> mogelijkheden, string tekstBijOptie0)
        {
            Console.WriteLine(titel);

            for (int i = 0; i < mogelijkheden.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {mogelijkheden[i].Omschrijving}");
            }

            Console.WriteLine("0. " + tekstBijOptie0);

            int getal;
            while (true)
            {
                getal = GeefStriktPositiefGetal("Maak je keuze: ");
                if (getal <= mogelijkheden.Count && getal >= 0)
                {
                    break;
                }
                Console.WriteLine($"Keuze moet in het interval [0, {mogelijkheden.Count}] liggen");
            }
            return getal;
        }

        private int GeefStriktPositiefGetal(string prompt)
        {
            Console.Write(prompt);
            return int.TryParse(Console.ReadLine(), out int result) ? result : -1;
        }

    }
}
