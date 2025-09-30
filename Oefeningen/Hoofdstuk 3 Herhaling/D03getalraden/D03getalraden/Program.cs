namespace D03getalraden
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("De computer denkt aan getal tussen 0 en 10. ");
            Random r = new Random();
            int random = r.Next(0,10);

            Console.WriteLine("Geef uw gok in. ");
            string gokText = Console.ReadLine();    
            int gok = int.Parse(gokText);

            if (gok == random)
            {
                Console.WriteLine($"U hebt goed geraden !");
            }
            else
            {
                Console.WriteLine($"Helaas het getal was {random} ");
            }
        }
    }
}
