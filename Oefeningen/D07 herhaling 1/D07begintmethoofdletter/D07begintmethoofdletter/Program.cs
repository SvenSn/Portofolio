namespace D07begintmethoofdletter
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Geef een tekst: ");
            string tekst = Console.ReadLine();

            if (char.IsUpper(tekst[0]))
            {
                Console.WriteLine("De tekst begint met een hoofdletter.");
            }
            else
            {
                Console.WriteLine("De tekst begint niet met een hoofdletter.");
            }
        }
    }
}
