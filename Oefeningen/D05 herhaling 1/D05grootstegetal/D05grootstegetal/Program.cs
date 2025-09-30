namespace D05grootstegetal
{
    internal class Program
    {
        static void Main(string[] args)
        {
           int grootsteGetal = 0;
           int getal = 0;
            do
            {

                Console.WriteLine("Geef een getal in: (-1 om te stoppen)");
                getal = int.Parse(Console.ReadLine());

                if (getal != -1)
                {
                    if (getal > grootsteGetal)
                    {
                        grootsteGetal = getal;
                    }
                }

            } while (getal != -1);

            Console.WriteLine($"Het grootste getal is: {grootsteGetal}");
        }
    }
}
