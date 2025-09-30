using System.Diagnostics.CodeAnalysis;

namespace D09maximumtemperatuur
{
    internal class Program
    {
        static void Main(string[] args)
        {

            const double error = -9999.0;
            double[] meetwaarden = { 13.4, 12.1, 10.8, 10.8, 10.3, 8.9, 7.9, 7.8, 7.4, 7.2, 6.4, 9.7, 13.7, 17.2, 19.6, -9999.0, -9999.0, 22.4, 22.7, 22.8, 22.3, 18.4 };

            double min = meetwaarden[0];
            double max = meetwaarden[0];

            foreach (double d in meetwaarden)
            {
                if (d != error)
                {
                    min = Math.Min(min, d);
                    max = Math.Max(max, d);
                }
            }


            Console.WriteLine($"Min temp : {min} en max temp : {max}");
           
        }
    }
}
