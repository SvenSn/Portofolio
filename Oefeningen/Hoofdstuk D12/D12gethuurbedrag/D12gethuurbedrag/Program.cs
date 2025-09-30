namespace D12gethuurbedrag
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine(GetHuurBedrag(new DateTime(2022, 11, 20, 16, 45, 00), new DateTime(2022, 11, 20, 17, 15, 00), 10));
            Console.WriteLine(GetHuurBedrag(new DateTime(2022, 11, 20, 16, 45, 00), new DateTime(2022, 11, 23, 16, 15, 00), 10));
            Console.WriteLine(GetHuurBedrag(new DateTime(2022, 11, 20, 16, 45, 00), new DateTime(2022, 11, 23, 17, 15, 00), 10));
            GetHuurBedrag(new DateTime(2022, 11, 20, 16, 45, 00), new DateTime(2022, 11, 20, 17, 15, 00), 10);
            GetHuurBedrag(new DateTime(2022, 11, 20, 16, 45, 00), new DateTime(2022, 11, 23, 16, 15, 00), 10);
            GetHuurBedrag(new DateTime(2022, 11, 20, 16, 45, 00), new DateTime(2022, 11, 23, 17, 15, 00), 10);


            static double GetHuurBedrag(DateTime afgehaald, DateTime teruggebracht, double dagPrijs)
            {
                TimeSpan ts = teruggebracht - afgehaald;


                // ceiling pakken sinds iedere begonnen dag
                int aantalDagen = (int)Math.Ceiling(ts.TotalDays);

                

                double prijs = dagPrijs*aantalDagen;

                return prijs;
            }
        }
    }
}
