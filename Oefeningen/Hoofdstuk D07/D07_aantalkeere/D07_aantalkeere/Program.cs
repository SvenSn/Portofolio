namespace D07_aantalkeere
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Schrijf een programma dat de gebruiker om tekst vraagt en toont hoeveel keer de letter 'e' voorkomt (hoofdletterongevoelig).

            Console.WriteLine("Geef een tekst in: ");
            string tekst = Console.ReadLine();

            int eTeller = 0;


            foreach (char c in tekst.ToLower())
            {
                if (c == 'e')
                {
                    eTeller++;
                }


            }

            Console.WriteLine($"'e' komt {eTeller} voor.");
        
        }
    }
}
