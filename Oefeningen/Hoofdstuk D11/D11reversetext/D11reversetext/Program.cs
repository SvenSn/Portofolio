
namespace D11reversetext
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Schrijf een programma dat de gebruiker om een tekst vraagt en deze achterstevoren op het scherm zet.


            Console.Write("Geef een tekst in. ");
            string tekst = Console.ReadLine();


            string output = ReverseTekst(tekst);

            Console.WriteLine(output);
        }

        private static string ReverseTekst(string? tekst)
        {
            string reversed = "";

            foreach (char c in tekst)
            {
                reversed = c + reversed;
            }
            return reversed;
        }
    }
}
