namespace D07_karakterperpositie
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Schrijf een programma dat de gebruiker om tekst vraagt en voor elke positie toont welk karakter op die positie staat.

            Console.Write("Geef een tekst: ");
            string invoer = Console.ReadLine();


            // for loop om iedere char te tellen en positie te geven 

        for (int i = 0; i <= invoer.Length; i++)
            {
                char c = invoer[i];
                Console.WriteLine($"{i, 2:d} = {c}");


            }


        }
    }
}
