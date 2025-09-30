namespace D09getalfrequentie
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] getallen = new int[11];

            string invoer;

            do
            {

                Console.Write("Geef een getal in [0,10] : ");
                invoer = Console.ReadLine();

                if (invoer.ToLower().Trim() != "stop")
                {
                    int getal = int .Parse(invoer);
                    getallen[getal]++;

                }

            } while (invoer.ToLower().Trim() != "stop");


            for (int i = 0; i < getallen.Length; i++)
            {
                int index = i;
                int aantalKeer = getallen[index];

                if (aantalKeer > 0)
                {
                    Console.WriteLine($"{index} komt {aantalKeer} aantal keer voor.");
                }
            }
        }
    }
}
