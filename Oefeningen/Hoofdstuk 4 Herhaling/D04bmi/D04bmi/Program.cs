namespace D04bmi
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Geef je lengte in cm. ");
            string lengteText = Console.ReadLine();
            int lengte = int.Parse(lengteText);

            Console.WriteLine("Geef uw gewicht in kg");
            string gewichtText = Console.ReadLine();
            int gewicht = int.Parse(gewichtText);


            double lengteM = lengte / 100.0;

            double bmi = gewicht / (Math.Pow(lengteM, 2));


            string bmiIndex = "";

            if (bmi < 18.5 )
            {
                bmiIndex = "ondergewicht";
            }
            else if (bmi < 25)
            {
                bmiIndex = "normaal gewicht";
            }
            else if (bmi < 30)
            {
                bmiIndex = "overgewicht";
            }
            else if (bmi < 40)
            {
                bmiIndex = "zwaarlijvigheid";
            }
            else
            {
                bmiIndex = "ernstige zwaarlijvigheid";
            }


            Console.WriteLine($"BMI: {bmi} ({bmiIndex})");
        }
    }
}
