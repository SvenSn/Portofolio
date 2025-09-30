namespace D07_achterstevoren
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Schrijf een programma dat de gebruiker om tekst vraagt en vervolgens die tekst achterstevoren weergeeft.

            Console.Write("Geef een tekst: ");
            string tekst = Console.ReadLine();

            for (int i = tekst.Length -1; i >= 0; i--)
            {
                char c = tekst[i];
                Console.Write(c);
            }

        }
    }
}
