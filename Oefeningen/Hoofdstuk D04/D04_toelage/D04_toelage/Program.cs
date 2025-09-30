namespace D04_toelage
{
    internal class Program
    {
        static void Main(string[] args)

        /* Een bepaalde instantie voorziet in een toelage bovenop het inkomen van grote minderbedeelde gezinnen. 
         * De toelage - bedraagt 3% van het jaarinkomen - vervalt indien het jaarinkomen meer is dan 20000Eur of het aantal kinderen minder is dan 3.
          Schrijf een programma dat de gebruiker om het jaarinkomen en aantal kinderen vraagt, en vervolgens de toelage voor dat gezin toont.*/
        {
            Console.WriteLine("Wat is uw jaarinkomen?");
            double jaarInkomen = Int32.Parse(Console.ReadLine());

            Console.WriteLine("Hoeveel kinderen heeft u");
            int aantalKinderen = Int32.Parse(Console.ReadLine());

            double toelage;

            if (aantalKinderen >= 3 && jaarInkomen < 20000.0)
            {
                toelage = (jaarInkomen / 100.0) * 3;

                Console.WriteLine($"Uw toelage bedraagt: {toelage} ");
            }
            else
            {
                Console.WriteLine("U heeft geen recht op de toelage");
            }


            
        }
    }
}
