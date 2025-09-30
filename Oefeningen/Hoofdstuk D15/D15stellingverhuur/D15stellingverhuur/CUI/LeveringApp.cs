using D15stellingverhuur.Domein;

namespace D15stellingverhuur.CUI
{
    public class LeveringApp
    {
        public void Run()
        {
            
            DateTime startVerhuur = new DateTime(2022, 1, 1, 8, 0, 0);
            DateTime eindVerhuur = new DateTime(2022, 2, 1, 16, 30, 0);

            // Op basis van een start- en eindmoment kan een StellingVerhuring worden aangemaakt...
            StellingVerhuring sv1 = new StellingVerhuring(startVerhuur, eindVerhuur);

            // Van een StellingVerhuring kan je het aantal uur opbouw en afbraak opvragen...
            int aantalUurOpbouw = sv1.AantalUurOpbouw;
            int aantalUurAfbraak = sv1.AantalUurAfbraak;
            Console.WriteLine(aantalUurOpbouw);   // by default is dit 8u opbouw
            Console.WriteLine(aantalUurAfbraak);  // by default is dit 4u afbraak

            // Van een StellingVerhuring kan je de NettoVerhuurPeriode opvragen...
            Periode verhuurPeriode = sv1.NettoVerhuurPeriode();

            // Deze verhuurPeriode heeft een Start en Eind tijdstip...
            // Het start tijdstip is het startmoment van de StellingVerhuring verhoogd met het
            // aantal uren opbouw...
            DateTime startTijdstip = verhuurPeriode.Start;
            Console.WriteLine(startTijdstip);  // 1 jan 2022 16u (8u na het startmoment)
            // Het eind tijdstip is het eindmoment van de StellingVerhuring verlaagd met het
            // aantal uren afbraak...
            DateTime eindTijdstip = verhuurPeriode.Eind;
            Console.WriteLine(eindTijdstip);   // 1 feb 2022 12u30 (4u voor het eindmoment)

            // Deze verhuurPeriode heeft dan ook een bepaald aantal uur...
            // Dit aantal uur is in geval van .5 naar boven afgerond...
            int aantalUur = verhuurPeriode.AantalUur();
            Console.WriteLine(aantalUur);  // 741 (in plaats van 740.5)

            // De prijs van een StellingVerhuring kan worden opgevraagd...
            // De prijs wordt minimaal berekend op aantal...
            // . uren opbouw (90 per uur)         90 x   8 =  720
            // . netto uren verhuur (5 per uur)    5 x 741 = 3705
            // . uren afbraak (60 per uur)        60 x   4 =  240
            decimal prijs = sv1.Prijs();  //               + -----
            Console.WriteLine(prijs);     //                 4665   (= 720 + 3705 + 240)

            // Het aantal uur opbouw of afbraak van een StellingVerhuur kan worden aangepast...
            sv1.AantalUurOpbouw = 5;
            sv1.AantalUurAfbraak = 3;
            // Dit zal zijn impact hebben op de NettoVerhuurPeriode, of op zijn minst op
            // het start en eind tijdstip van deze NettoVerhuurPeriode...
            verhuurPeriode = sv1.NettoVerhuurPeriode();
            Console.WriteLine(verhuurPeriode.Start);  // 1 jan 2022 13u (3u vroeger dan voorheen)
            Console.WriteLine(verhuurPeriode.Eind);   // 1 feb 2022 13u30 (1u later dan voorheen)
            // En zal zijn impact hebben op de prijs...
            Console.WriteLine(sv1.Prijs());  // 4355

            // Je kan ook Leveringen aanmaken...
            // De zijn elk naar een bepaald Adres, en betreffen een bepaalde AfstandInKm...
            Levering leveringX = new Levering("Antwerpen", 62);
            Levering leveringY = new Levering("Gent", 43);
            // Het Adres en de AfstandInKm kan uiteraard van een Levering opgevraagd worden...
            string adres = leveringX.Adres;
            Console.WriteLine(adres);        // Antwerpen
            int afstandInKm = leveringY.AfstandInKm;
            Console.WriteLine(afstandInKm);  // 43
            
            // Van een StellingVerhuur kan de Levering worden ingesteld...
            sv1.Levering = leveringY;
            // Deze kan naderhand uiteraard ook worden opgevraagd...
            Levering leveringSv1 = sv1.Levering;
            Console.WriteLine(leveringSv1.Adres);        // Gent
            Console.WriteLine(leveringSv1.AfstandInKm);  // 43
            // De prijs van de StellingVerhuring zal hiermee ook verhogen op basis van het aantal...
            //                              4355
            // . km (10 per km)   10 x 43 =  430
            //                            + ----
            //                              4785
            Console.WriteLine(sv1.Prijs());
        }
    }
}
