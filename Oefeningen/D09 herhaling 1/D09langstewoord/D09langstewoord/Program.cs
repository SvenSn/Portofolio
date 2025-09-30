namespace D09langstewoord
{
    internal class Program
    {
        static void Main(string[] args)
        {
            char[] leesTekens = new char[] {' ','.',',','!','?'};

            Console.Write("Geef een tekst in: ");
            string invoer = Console.ReadLine();

            string[] woorden = invoer.Split(leesTekens);


            int aantal = 0;
            string langsteWoord = "";
            foreach (string woord in woorden)
            {
                if (woord != "")
                {
                    aantal++;
                    if (woord.Length > langsteWoord.Length)
                    {
                        langsteWoord = woord;
                    }
                }
            }

            Console.WriteLine($"Het aantal woorden is : {aantal}");
            Console.WriteLine($"Het langste woord is {langsteWoord}");
        }
    }
}
