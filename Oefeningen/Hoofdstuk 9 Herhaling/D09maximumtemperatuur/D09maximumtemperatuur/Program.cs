namespace D09maximumtemperatuur
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double[] meetwaarden = { 13.4, 12.1, 10.8, 10.8, 10.3, 8.9, 7.9, 7.8, 7.4, 7.2, 6.4, 9.7, 13.7, 17.2, 19.6, -9999.0, -9999.0, 22.4, 22.7, 22.8, 22.3, 18.4 };

            const double errorSensor = -9999.0;

            double minTemp = meetwaarden[0];
            double maxTemp = meetwaarden[1];    

            foreach  (double waarden in meetwaarden)
            {
                if (waarden != errorSensor)
                {
                    minTemp = Math.Min(minTemp, waarden);
                    maxTemp = Math.Max(maxTemp, waarden);
                } 
            }


            Console.WriteLine($"Min temp is {minTemp} en max temp is {maxTemp}. ");
        }
    }
}
