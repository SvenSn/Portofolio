namespace D02volwassen
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Geef uw leeftijd in. ");
            string leeftijdText = Console.ReadLine();
            int leeftijd = int.Parse(leeftijdText);

            string leeftijdCheck = "";

            if (leeftijd < 18)
            {
                leeftijdCheck = "niet";
            }
            else
            {
                leeftijdCheck = "wel";
            }

            Console.WriteLine($"Je bent {leeftijdCheck} volwassen");
        }
    }
}
