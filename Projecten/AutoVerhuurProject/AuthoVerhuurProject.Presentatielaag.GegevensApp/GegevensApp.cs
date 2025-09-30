
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Numerics;

namespace AuthoVerhuurProject.Presentatielaag.GegevensApp
{
    public class GegevensApp(csv bestandsVerwerker)
    {
       

        public void Run()
        {
            bestandsVerwerker = new CSVVerwerkerDB(@"Data Source=SVEN\SQLEXPRESS;Initial Catalog=AutoVerhuurDataseBase;Integrated Security=True;Encrypt=True;Trust Server Certificate=True");

            //legen van de database bij opstart
            bestandsVerwerker.LeegDatabase();

            //naar current directory gaan kijken 

            string mapBestanden = "C:\\Users\\compl\\Documents\\GitHubRep\\SvenSnoeck_TakenProg\\ProgGov\\Portifolio\\AutoVerhuurProject\\Data";

            //bestandslocaties

            string klanten = Path.Combine(mapBestanden, "Klanten.csv");
            string autos = Path.Combine(mapBestanden, "Autos.csv");
            string vestigingen = Path.Combine(mapBestanden, "Vestigingen.csv");

            
            try
            {
                bestandsVerwerker.VerwerkAutos(autos);
                bestandsVerwerker.VerwerkKlanten(klanten);
                bestandsVerwerker.VerwerkVestigingen(vestigingen);
                bestandsVerwerker.KoppelAutosAanVestigingen();
                Console.WriteLine("Gegevens werden uitgelezen en weggeschreven");
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine("De database werd niet succesvol gevuld." + ex.Message);
            }
        }
    }
}
