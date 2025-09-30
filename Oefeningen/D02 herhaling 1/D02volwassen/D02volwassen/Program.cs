namespace D02volwassen
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Geef uw leeftijd in: ");
            int leeftijd = Int32.Parse(Console.ReadLine());


            Console.Write("je bent ");
            if (leeftijd >= 18)
            {
                Console.Write("wel ");
            } else
            {
                Console.Write("niet ");
            }
            Console.Write("volwassen.");
        }
    }
}
