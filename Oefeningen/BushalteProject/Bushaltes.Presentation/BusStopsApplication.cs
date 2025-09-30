using BusStops.Domain;
using System;

namespace BusStops.Presentation
{
    public class BusStopsApplication
    {
        private DomainController _domainController;
        public BusStopsApplication(DomainController domainController)
        {
            _domainController = domainController;
        }


        public void Run()
        {
                bool running = true;

            while (running)
            {
                Console.WriteLine("================================================================================= \n");
                Console.WriteLine("1.Print uit hoeveel haltes er zijn");
                Console.WriteLine("2.Print alle halte namen uit");
                Console.WriteLine("3.Geef lijst met de gemeentenamen, alfabetisch gesorteerd, zonder duplicaten.");
                Console.WriteLine("4.Geef lijst van haltenamen voor een gemeente die de gebruiker kan kiezen.");
                Console.WriteLine("5.Geef een lijst met haltes waar geen HalteToegankelijkheden zijn.");
                Console.WriteLine("6.Print de gemeente met het meeste aantal haltes uit met het aantal.");
                Console.WriteLine("7.Print voor elke gemeente uit hoeveel haltes ze heeft.");
                Console.WriteLine("8.Voorzie een functie die voor 2 opgegeven gemeenten de gemeenschappelijke lijst vanhaltenamen weergeeft.");
                Console.WriteLine("9.Voorzie  een  functie  die  de  haltes  weergeeft die enkel voorkomen in de door de gebruikeropgegeven gemeente, maar die niet voorkomen in bij de andere gemeenten.");
                Console.WriteLine("10.Geef de langste haltenaam weer.");
                Console.WriteLine("11.Geef een lijst met haltes die in meerdere gemeenten voorkomen (en print ook af in welkegemeenten ze voorkomen).");
                Console.WriteLine("0.Stoppen");
                Console.WriteLine("================================================================================= \n");


                Console.WriteLine("Alle toegankelijkheden");
                _domainController.GeefAlleToegankelijkHeden();

                Console.WriteLine("================================================================================= \n");
                Console.WriteLine("Maak uw keuze: ");
                string input = Console.ReadLine();
                int aantal = int.Parse(input);
                Console.WriteLine("================================================================================= \n");



                switch (aantal)
                {
                    case 0: running = false; 
                        break;
                    case 1:
                        _domainController.GeefAlleHaltes();
                        break;

                    case 2: _domainController.GeefAlleHalteNamen();
                        break;
                    case 3: _domainController.GeefAlleGemeenteNamenAlfabetisch();
                        break;
                    case 4 : _domainController.GeefHalteNamenGegevenGemeente();
                        break;
                    case 5: _domainController.GeefHaltesZonderToegankelijkheden();
                        break;
                    case 6: _domainController.GeefGemeenteMetMeesteHaltes();
                        break;
                    case 7: _domainController.GeefAantalHaltesPergemeente();
                        break;
                    case 8: _domainController.GeefGedeeldeHaltes();
                        break;
                    case 9: _domainController.GeefUniekeHaltesPerGemeente();
                        break;
                    case 10: _domainController.GeefLangsteHaltnaam();
                        break;
                    case 11: _domainController.GeefAllesharedHaltesGemeente();
                        break;

                }

            }
        }

    }
}