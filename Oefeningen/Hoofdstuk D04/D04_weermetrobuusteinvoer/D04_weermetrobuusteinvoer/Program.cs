namespace D04_weermetrobuusteinvoer
{
    internal class Program
    {
        static void Main(string[] args)
        {


            Console.Write("Schijnt de zon (ja/nee)?: ");
            string zon = Console.ReadLine().ToLower().Trim();
            bool deZonSchijnt = (zon == "ja");

            Console.Write("Regent het (ja/nee)?: ");
            string regen = Console.ReadLine().ToLower().Trim();
            bool hetRegent = (regen == "ja");

            if (deZonSchijnt)
            {
                if (hetRegent)
                {
                    Console.WriteLine("Regenboog");
                }
                else if (!hetRegent)
                {
                    Console.WriteLine("Mooi weer");
                }
                else
                {
                    Console.WriteLine("Saaie dag");
                }
            }
            else
            {
                Console.WriteLine("Slecht weer");
            }

        }
    }
}
