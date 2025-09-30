namespace D09_maximumtemperatuur
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Schrijf een programma dat de minimum en maximumtemperatuur van een bepaalde dag weergeeft, gebaseerd op een lijst van meetwaarden van die dag.


            double[] meetwaarden = { 13.4, 12.1, 10.8, 10.8, 10.3, 8.9, 7.9, 7.8, 7.4, 7.2, 6.4, 9.7, 13.7, 17.2, 19.6, -9999.0, -9999.0, 22.4, 22.7, 22.8, 22.3, 18.4 };

            //double aanmaken voor de sensor error -9999.0
            const double sensorError = -9999.0;

            double maxTemp = meetwaarden[0];
            double minTemp = meetwaarden[0];

           foreach (double meetwaardenGetal in meetwaarden)
            {
                if (meetwaardenGetal != sensorError)
                {
                    minTemp = Math.Min(minTemp, meetwaardenGetal);
                    maxTemp = Math.Max(maxTemp, meetwaardenGetal);
                }
            }

           Console.WriteLine($"Minimum temp is {minTemp} en max is {maxTemp}");
        }
    }
}
