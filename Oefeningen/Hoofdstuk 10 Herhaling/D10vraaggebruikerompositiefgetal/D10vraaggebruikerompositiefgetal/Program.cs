

using System.Runtime.Intrinsics.Arm;

namespace D10vraaggebruikerompositiefgetal
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int breedte = VraagGebruikerOmPositiefGetal("Geef de breedte : ");
            int hoogte = VraagGebruikerOmPositiefGetal("Geef de hoogte : ");
            Console.WriteLine();

            ToonRechthoek(breedte, hoogte);
        }

        private static int VraagGebruikerOmPositiefGetal(string vraag)
        {
            bool gelukt;
            int getal;


            do
            {
                Console.WriteLine(vraag);
                string invoerText = Console.ReadLine();
                gelukt = int.TryParse(invoerText, out getal);
            } while (!gelukt || getal < 1);

            return getal;
        }

        static void ToonRechthoek(int breedte, int hoogte)
        {
            for (int i = 0; i < hoogte; i++)
            {
                // teken 1 regel van 'breedte' sterretjes
                for (int k = 0; k < breedte; k++)
                {
                    Console.Write("*");
                }
                Console.WriteLine();
            }
        }
    }
}
