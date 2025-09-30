namespace D08_rijen
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Schrijf een programma dat kan nagaan of een rij getallen een rekenkundige dan wel meetkundige rij is.
            //Een rekenkundige rij is een rij getallen waarbij het verschil tussen 2 opeenvolgende getallen steeds gelijk is
            //Een meetkundige rij is een rij getallen waarbij een getal steeds gelijk is aan het vorige getal maal eenzelfde factor.


            double[] getal = new double[6];


            int teller = 0;

            bool isRekenKundig = true;
            bool isMeetKundig = true;
            

            for (int index = 0; index < getal.Length; index++)
            {
                Console.WriteLine("Geef een getal: ");
                string invoer = Console.ReadLine();

                double.TryParse(invoer, out double getallen);
                getal[index] = getallen;
                teller++;

                if (string.IsNullOrEmpty(invoer) && index >= 3)
                {
                    teller = teller - 1;
                    break;
                   
                }
            }

            double verschil = getal[1] - getal[0];
            double factor = getal[1] / getal[0];

            for (int index = 0;index < teller - 1; index++)
            {
                if (getal[index] > 0)
                {

                    if (getal[index + 1] - getal[index] != verschil)
                    {
                        isRekenKundig = false;

                    }
                    if (getal[index+1] / getal[index] != factor)
                    {

                        isMeetKundig = false;

                    }
                }

            }
            if (isRekenKundig)
            {
                Console.WriteLine($"Deze rij getallen is Rekenkundig met delta {verschil} ");
                Console.WriteLine(string.Join(", ", getal));
            }
            else if (isMeetKundig)
            {
                Console.WriteLine($"Deze rij getallen is meetkundig met factor {factor}");
                Console.WriteLine(string.Join(", ", getal));
            }
            else
            {
                Console.WriteLine("Deze rij getallen is een gewone rij");
                Console.WriteLine(string.Join(", ", getal));
            }


           
        }
    }
}
