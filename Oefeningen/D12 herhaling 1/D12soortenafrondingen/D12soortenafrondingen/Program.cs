namespace D12soortenafrondingen
{
    internal class Program
    {
        static void Main(string[] args)
        {
            decimal[] waarden = { 7.4m, 7.5m, 7.6m, -7.4m, -7.5m, -7.6m };

            foreach(decimal d in waarden)
            {
                decimal mc = Math.Ceiling(d);
                decimal mf = Math.Floor(d);
                decimal mr = Math.Round(d);
                decimal mrd = Math.Round(d,MidpointRounding.AwayFromZero);
                Console.WriteLine($"{mc} | {mf} | {mr} | {mrd}");
            }
        }
    }
}
