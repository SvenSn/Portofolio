namespace D08omgekeerdevolgorde
{
    internal class Program
    {
        static void Main(string[] args)
        {

            string[] namen = new string[4];
            for (int i  = 0; i < namen.Length; i++)
            {
                Console.Write($"Geef naam {i+1}: ");
                string naam = Console.ReadLine(); 
                namen[i]= naam;

            }

            for (int i = namen.Length-1; i>= 0; i--)
            {
                Console.WriteLine(namen[i]);
            }
        }
    }
}
