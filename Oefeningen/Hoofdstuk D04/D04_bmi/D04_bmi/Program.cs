namespace D04_bmi
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Maak een programma om onderstaand programmaverloop te bekomen…​ . 
            Console.WriteLine("Geef uw lengte in cm.");
            int lengteInCm = Int32.Parse(Console.ReadLine());

            Console.WriteLine("Geef uw gewicht in kg in.");
            int gewichtInKg = Int32.Parse(Console.ReadLine());

            double bmi = gewichtInKg / Math.Pow(lengteInCm / 100.0, 2);


            //if structuren maken voor bmi checks 
            /*Onder de 18,5: ondergewicht.

            Vanaf 18,5 en minder dan 25: normaal gewicht.

            Vanaf 25 en minder dan 30: overgewicht.

            Vanaf 30 en minder dan 40: zwaarlijvigheid.

            Vanaf 40: ernstige zwaarlijvigheid. */

            // string aanmaken voor het bmi gewichtsklasse om deze dan te gebruiken in de ifs 
            // om verschillende tekst weer te geven met de correcte gewichtsklasse van bmi

            string bmiGewichtsKlasse = "Normaal gewicht";  
            if (bmi >= 40)
            {
                bmiGewichtsKlasse = "Ernstige zwaarlijvigheid";
            }
            else
            {
                if (bmi >= 30)
                {
                    bmiGewichtsKlasse = "Zwaarlijvigheid";
                }
                else
                {
                    if (bmi >= 25)
                    {
                        bmiGewichtsKlasse = "Overgewicht";
                    }
                    else
                    {
                       if(bmi < 18.5)
                        {
                            bmiGewichtsKlasse = "Ondergewicht";
                        }
                    }
                }
            }
            Console.WriteLine($"Jouw BMI is : {bmi} en je hebt {bmiGewichtsKlasse}");
        }
    }
}
