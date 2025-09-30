namespace D01_bmi
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int lengteInCm = 182;
            int gewichtInKg = 72;
            
            // lengte in cm omzetten naar lengte in meter door te delen door 100 , moet double zijn omdat het geen geheel getal is 
            // dan bmi variabele maken en de waarde toekennen van gewicht in kg gedeelt door het kwadraat van lengte in meters wat in dit geval 1.82 is; 
           
            double lengteInM = lengteInCm /100.0;
            double bmi = gewichtInKg / (lengteInM * lengteInM);

            Console.WriteLine(bmi);
        }
    }
}
