namespace D08omgekeerdevolgorde
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] namen = new string[4];


            for (int i = 0; i < namen.Length; i++)
            {
                Console.Write("Geef een naam: ");
                namen[i] = Console.ReadLine();
            }

            for (int index = namen.Length - 1; index >= 0; index--)
            {
                Console.WriteLine(namen[index]);    
            }
        }
    }
}
