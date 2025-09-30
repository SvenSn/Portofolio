
namespace D10bevat
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] dieren = { "hond", "kat", "olifant", "krokodil" };

            Console.WriteLine(Bevat(dieren, "papegaai"));
            Console.WriteLine(Bevat(dieren, "olifant"));
        }

        private static bool Bevat(string[] dieren, string vraag)
        {
            foreach (string dier in dieren)
            {
                if(dier == vraag)
                {
                    return true;
                }
            }
            return false;
            
        }
    }
}
