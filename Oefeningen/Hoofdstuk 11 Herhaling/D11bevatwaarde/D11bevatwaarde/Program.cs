
namespace D11bevatwaarde
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] getallen = new int[5];
            int aantal = 0;
            do
            {

                Console.WriteLine($"Geef getal #{aantal+1}");
                string invoer = Console.ReadLine(); 

                int getal = 0;
                if (int.TryParse(invoer, out getal))
                {
                    bool isGevonden = BevatWaarde(getallen, getal);

                    if (!isGevonden)
                    {
                        getallen[aantal] = getal;
                        aantal++;
                    }
                } 
                else
                {
                    continue;
                }             
            } while (aantal < 5);


            Console.WriteLine("De unieke getallen zijn" + string.Join(", ",getallen));
        }

        private static bool BevatWaarde(int[] getallen, int getal)
        {

            bool gevonden = false;  
            foreach (int i in getallen)
            {
                if (i == getal)
                {
                   gevonden =  true;
                    break;
                }
                else
                {
                   gevonden = false;
                }
            }
            return gevonden;
        }
    }
}
