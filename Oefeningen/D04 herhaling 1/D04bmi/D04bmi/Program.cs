namespace D04bmi
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("lengte in cm?: ");
            int lengteCm = int.Parse(Console.ReadLine());

            Console.Write("Gewicht in kg?: ");
            int gewichtKg = int.Parse(Console.ReadLine());
            double lengteM = lengteCm / 100.0;

            double BMI = gewichtKg / (lengteM * lengteM);

            


            string bmiTekst = "";

           if (BMI < 18.5)
            {
                bmiTekst = "ondergewicht";
            }
           else if (BMI < 25)
            {
                bmiTekst = "Normaal gewicht";
            }
           else if (BMI < 30)
            {
                bmiTekst = "overgewicht";
            }
           else if (BMI < 40)
            {
                bmiTekst = "zwaarlijvigheid";
            }
           else
            {
                bmiTekst = "ernstige zwaarlijvigheid";
            }

            Console.WriteLine($"{BMI} ({bmiTekst})");
        }
    }
}
