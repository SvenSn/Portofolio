namespace D08_omgekeerdevolgordehoeveel
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Console.Write("Hoeveel namen wil je in geven? ");
            int namenNummer = int.Parse(Console.ReadLine());

            string[] namen = new string[namenNummer];


            for (int i = 0; i < namenNummer; i++)
            {
                Console.Write($"Geef een naam {i+1}. ");
                namen[i] = Console.ReadLine();
            }

            for (int index = namenNummer -1; index >= 0; index--)
            {
                Console.WriteLine(namen[index]);
            }

        }
    }
}
