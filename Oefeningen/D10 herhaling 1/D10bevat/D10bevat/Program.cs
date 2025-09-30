
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

        private static bool Bevat(string[] dieren, string zoekdier)
        {
            bool isGevonden = true;
            for(int i = 0; i < dieren.Length; i++)
            {
                if (dieren[i] == zoekdier)
                {
                    isGevonden = true;
                    break;
                }
                else
                {
                    isGevonden = false;
                }
            }
            return isGevonden;
        }
    }
}
