namespace D05_getalradengebruiker
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /* Schrijf een programma waarbij de gebruiker een getal moet raden (van 1 t.e.m. 100) dat de computer willekeurig gekozen heeft.*/

            Random r = new Random();
            int nrgGetal = r.Next(1, 100);

            int gok = 0;
            Console.WriteLine("De pc heeft een getal van 1 tot 100 bedacht.");
            
            do
            {
                Console.WriteLine("geef een een getal in als gok.");
                gok = Int32.Parse(Console.ReadLine());
                if (gok > nrgGetal)
                {
                    Console.WriteLine("Lager!");
                }
                else if (gok < nrgGetal)
                {
                    Console.WriteLine("Hoger!");
                }
                else
                {
                    Console.WriteLine("Je hebt het geraden!");
                }
            }
            while (gok != nrgGetal);
        }
    }
}
