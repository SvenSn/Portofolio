namespace D06_toonsomtussengrenzen
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //int bovengrens en ondergens
            int bovenGrens = 0;
            int onderGrens = 0;

            // inlezen en value geven aan deze twee inten anders dan 0for loop tussen deze twee inten

            Console.WriteLine("Geef de ondergens in.");
            onderGrens = Int32.Parse(Console.ReadLine());

            Console.WriteLine("geef de bovengrens in");
            bovenGrens += Int32.Parse(Console.ReadLine());

            int som = 0;

            for (int i = onderGrens + 1; i < bovenGrens; i++)
            {
                som += i;
               if (i != onderGrens + 1)
                {
                    Console.Write(" + ");
                }
                Console.Write(i);

                
            }
            Console.WriteLine($" = {som}");
        }
    }
}
