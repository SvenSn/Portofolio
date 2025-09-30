
namespace D11bevatwaarde
{
    internal class Program
    {
        static void Main(string[] args)
        {


            //Schrijf een programma dat de gebruiker om 5 unieke gehele getallen vraagt.

              int[] getallen = new int[5];

            int teller = 0;


              while (teller < 5)
            {
                Console.Write($"voer getal #{teller+1} in. ");
                string invoer = Console.ReadLine();

                if (int.TryParse(invoer, out int getal))
                {
                    if (!HeeftWaarde(getallen, getal))
                    {
                        getallen[teller] = getal;
                        teller++;
                    }
                }

            }

            Console.WriteLine(string.Join(", ",getallen));
              

            
        }

        private static bool HeeftWaarde(int[] getallen, int getal)
        {
            foreach (int i in getallen)
            {
                if (i == getal)
                {
                    return true;
                    break;
                }
          
            }
            return false;
        }
    }
}
