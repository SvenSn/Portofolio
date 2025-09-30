using D15rekeningkantoor.Domein;
using D15rekeningkantoormieke.Domein;
using System;

namespace D15rekeningkantoormieke.CUI
{
    public class RekeningApp
    {
        public void Run()
        {
            Adres adresJan = new Adres("Koekoekstraat", "70", "9090", "Melle"); //Jan Janssens, Koekoekstraat 70, 9090 Melle
            Persoon Jan = new Persoon("Jan", "Janssens", adresJan);


           
            //Deze rekening is bij het kantoor van Mieke Mickelsen, Kerkstraat 12, 8000 Brugge

            

            Adres adresMieke = new Adres("Kerkstraat", "99", "8000", "Brugge");
            
            Persoon Mieke = new Persoon("Mieke", "Mickelsen", adresMieke);
            Adres adresMiekeKantoor = new Adres("Kerkstraat", "12", "8000", "Brugge");
            Kantoor kantoor1 = new Kantoor(Mieke,adresMiekeKantoor);

            //Jan heeft een rekening met nummer BE11 2222 3333 4444 met daarop 120Euro

            Rekening rekeningJan = new Rekening("BE11 2222 3333 4444", 120.0, kantoor1, Mieke);

            //Jan Janssens, Koekoekstraat 70, 9090 Melle print

            Console.WriteLine($"{Jan.Voornaam} {Jan.FamilieNaam},{adresJan.Straat} {adresJan.Huisnummer}, {adresJan.Postcode} {adresJan.Gemeente}");


            


            //Jan heeft een rekening met nummer BE11 2222 3333 4444 met daarop 120Eur print

            Console.WriteLine($"{Jan.Voornaam} heeft een rekenening met nummer {rekeningJan.Nummer} met daarop {rekeningJan.Saldo} Euro.");

            //Deze rekening is bij het kantoor van Mieke Mickelsen, Kerkstraat 12, 8000 Brugge print

            Console.WriteLine($"Deze rekening is bij het kantoor van {kantoor1.Kantoorhouder}");

            //Mieke woont in haar kantoor print

            if (adresMieke == kantoor1.Adres1)
            {
                Console.WriteLine("Mieke woont in haar kantoor");
            }
            else
            {
                Console.WriteLine($"Mieke woont in {adresMieke.Straat} {adresMieke.Huisnummer}, {adresMieke.Postcode} {adresMieke.Gemeente}");
            }

        }
    }
}
