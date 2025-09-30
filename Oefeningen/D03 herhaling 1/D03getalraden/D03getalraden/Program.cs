namespace D03getalraden
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Random r = new Random();

            int getal = r.Next(0,10);


            Console.WriteLine("De Computer denkt aan een getal tussen 0 en 10.");
            Console.Write("Welk getal denkt u dat het is ? ");
            int gok = int.Parse(Console.ReadLine());
            

            if (gok == getal)
            {
                Console.WriteLine("Proficiat, u hebt goed geraden!");
            }
            else
            {
                    Console.WriteLine($"Helaas het getal was {getal}");
            }
        }
    }
}
