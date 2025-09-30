
namespace D10vraaggebruikerompositiefgetal
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int breedte = VraagGebruikerOmPositiefGetal("Geef de breedte: ");
            int hoogte = VraagGebruikerOmPositiefGetal("Geef de Hoogte: ");

            Console.WriteLine();

            toonrechthoek(breedte, hoogte);
        }

        private static int VraagGebruikerOmPositiefGetal(string vraag)
        {
            bool invoerOK;
            int getal; 

            do
            {
                Console.Write(vraag);
                string vraagje = Console.ReadLine();
                invoerOK = int.TryParse(vraagje, out getal);
            }while (!invoerOK || getal < 1);

            return getal;
        }
        private static void toonrechthoek(int breedte, int hoogte)
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
