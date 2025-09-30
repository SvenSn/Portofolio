
namespace D10_vraaggebruikerompositiefgetal
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Pas de oplossing van D10ToonRechthoek aan zodanig dat er een method VraagGebruikerOmPositiefGetal gebruikt wordt om de input af te handelen.

            int breedte = VraagGebuikerPositiefGetal("Geef de breedte : ");
            int hoogte = VraagGebuikerPositiefGetal("Geef de hoogte : ");

            

            ToonRechtHoek(breedte, hoogte);
        }

        private static int VraagGebuikerPositiefGetal(string vraag)
        {
            bool gelukt;
            int getal;
            do
            {


                Console.WriteLine(vraag);
                string breedteText = Console.ReadLine();
                gelukt = int.TryParse(breedteText, out getal);
            } while (!gelukt || getal < 1);

            return getal;
        }

        private static void ToonRechtHoek(int breedte, int hoogte)
        {
            for (int i = 0; i < hoogte; i++)
            {
                for (int j = 0; j < breedte; j++)
                {
                    Console.Write("*");
                }
                Console.WriteLine();
            }

        }

    
    }
}
