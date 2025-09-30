namespace D12kapitaalwelafgerond
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Geef het startkapitaal in. ");
            double startKapitaal = double.Parse(Console.ReadLine());

            Console.Write("Geef het intrestvoet in % in. ");
            int intrestVoet = int.Parse(Console.ReadLine());

            double jaarlijksIntrest = 1 + intrestVoet / 100.0;


            double bedrag = Math.Round(startKapitaal,2);


            for (int i = 0; i <= 20; i++)
            {
                Console.WriteLine($"jaar {i} heeft een kapitaal van {bedrag:F2}");

                bedrag *= jaarlijksIntrest;
                bedrag = Math.Round(bedrag, 2);
            }
        }
    }
}
