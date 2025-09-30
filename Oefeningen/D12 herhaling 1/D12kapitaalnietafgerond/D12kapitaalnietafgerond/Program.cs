namespace D12kapitaalnietafgerond
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Geef een kapitaal in: ");
            double kapitaal = double.Parse(Console.ReadLine());

            Console.Write("Geef een interestvoet in (%): ");
            double aantalInterest = double.Parse(Console.ReadLine());
            double percentage = aantalInterest / 100.0;

            
            for (int i = 0; i <= 20; i++)
            {
                
                Console.WriteLine($"Jaar {i} : {kapitaal,2:f}");
                 kapitaal = (kapitaal * percentage) + kapitaal;
            }
        }
    }
}
