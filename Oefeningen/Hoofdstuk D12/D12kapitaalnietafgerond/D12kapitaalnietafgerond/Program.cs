namespace D12kapitaalnietafgerond
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /*Schrijf een programma dat de gebruiker om het startkapitaal vraagt en een intrestvoet (in %). Je mag ervan uitgaan dat de gebruiker braafjes de gevraagde waarden invoert. */


            Console.Write("Geef het startkapitaal in. ");
            double startKapitaal = double.Parse(Console.ReadLine());

            Console.Write("Geef het intrestvoet in % in. ");
            int intrestVoet = int.Parse(Console.ReadLine());    

            double jaarlijksIntrest = 1 + intrestVoet/100.0;


            double bedrag = startKapitaal;


            for (int i = 0; i <= 20; i++)
            {
                Console.WriteLine($"jaar {i} heeft een kapitaal van {bedrag:F2}");

                bedrag *= jaarlijksIntrest;
            }
        }
    }
}
