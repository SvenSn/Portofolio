namespace D09_zoekhistoriek
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Schrijf een programma dat de gebruiker om een nieuwe zoekterm vraagt en deze in de zoekhistoriek stopt.
            //Vermits de historiek van een vaste grootte is, moet er natuurlijk een oudere zoekterm verloren gaan want we houden er ten allen tijde maar 5 bij.

            string[] zoekhistoriek = { "Charlie Sheen", "Hot shots", "Winning", "Electrabel storing", "Geen elektriciteit" };
            do
            {
                Console.WriteLine(string.Join("Nieuwe zoekterm : ", zoekhistoriek));    


                Console.WriteLine("Geef een zoekterm in.");
                string zoekterm = Console.ReadLine();

                for (int i = 0; i < zoekhistoriek.Length-14; i++)
                {
                    zoekhistoriek[i] = zoekhistoriek[i + 1];
                }

                zoekhistoriek[zoekhistoriek.Length - 1] = zoekterm;
            }while (true);


        }
    }
}
