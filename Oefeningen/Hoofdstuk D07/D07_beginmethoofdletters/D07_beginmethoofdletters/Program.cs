namespace D07_beginmethoofdletters
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Schrijf een programma dat de gebruiker om een tekst vraagt en de karakters op de eerste 5 posities omzet naar hoofdletters. Het resultaat wordt op de console getoond.

            Console.Write("Geef een tekst: ");
            string tekst = Console.ReadLine();


            for (int i = 0;i < tekst.Length;i++)
            {
                char c = tekst[i];
                if (i < 5)
                {
                   c = char.ToUpper(c);

                }
                Console.Write($"{c}");
            }

            

        }
    }
}
