namespace D07karakterperpositie
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Geef een teskt: ");
            string invoer = Console.ReadLine();

            for (int i = 0; i < invoer.Length; i++)
            {
                char c = invoer[i];
                Console.WriteLine($"{i,2:d} = {c}");
            }
        }
    }
}
