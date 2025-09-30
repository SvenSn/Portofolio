using AutoVerhuurProject.Domein;
using AutoVerhuurProject.Domein.DTOs;
using System.Reflection.Metadata;

namespace AutoVerhuurProject.Presentatielaag.ReserveringApplaag
{
    public class ReserveringApp(ReserveringManager reserveringManager)
    {
       

        public void Run()
        {
           

            DateTime vandaag = DateTime.Now;
            DateTime morgen = vandaag.AddDays(2.0);
            DateTime toekkomst = morgen.AddDays(1.0);
            //reserveringManager.VoegReserveringToe(new KlantDTO("sven", "snoeck", "hhpsihf", "hoogstraat", "9270", "laarne", "belgie"),
            //  new VestigingDTO("schiphol","ook","6000","amsterdam","nederland"),new AutoDTO("555-afk","tesla",2,"Elektrisch"),morgen,toekkomst);

            // var resvering = reserveringManager.GeefReserveringenBijKlantNaam("sven", "snoeck");
            KlantDTO klant1 = reserveringManager.GeefKlantBijEmail("anna.jansen@example.com");

            Console.WriteLine(klant1.Achternaam);
            Console.WriteLine(klant1.Voornaam);

            //testing stuff 

            /*List<AutoDTO> autos = reserveringManager.GeefAlleAutos().ToList();
            int teller = 0;

            foreach(AutoDTO  auto in autos)
            {
                Console.WriteLine(auto.Nummerplaat);
                teller++;
            }
            Console.WriteLine(teller);

            AutoDTO auto1 = reserveringManager.GeefAutoBijNummerplaat("BE-IAY-253");*/

            List<AutoDTO> autosv = reserveringManager.GeefAutosBijVestiging("schiphol").ToList();

            foreach ( AutoDTO auto in autosv)
            {
                Console.WriteLine(auto.Nummerplaat);
                Console.WriteLine(auto.Model);
            }
            string naam = "anna";

            List<KlantDTO> klanten = reserveringManager.GeefKlantenBijNaam(naam).ToList();

            foreach(KlantDTO klant in klanten)
            {
                Console.WriteLine(klant.Achternaam);
            }
           

            
        }
    }
}
