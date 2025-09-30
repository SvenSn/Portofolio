
namespace D11bevatwaarde
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int teller = 1;
            bool invoerOK;
            int[] getallen = new int[5];
            int getal = 0;

            do
            {

                Console.Write($"Geef getal #{teller} in: ");
                string invoer = Console.ReadLine();
                invoerOK = int.TryParse(invoer, out getal);

                if (BevatWaarde(getal, getallen) == false)
                {
                    getallen[teller - 1] = getal;
                    teller++;
                }


            } while (teller <= 5 || !invoerOK || !BevatWaarde(getal,getallen));

            Console.WriteLine($"De unieke getallen zijn: " + string.Join(", ", getallen));
        }

        private static bool BevatWaarde(int getal, int[] getallen)
        {
            bool WaardeGevonden = false;
            for(int i = 0; i < getallen.Length; i++)
            {
                if (getallen[i] == getal)
                {
                    WaardeGevonden = true;
                    break;
                }
            }
            return WaardeGevonden;
        }
    }
}
