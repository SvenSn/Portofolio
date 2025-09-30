namespace D12doorsnede
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double[] temperaturenMeetpunt1 = { 10.1, 20.2, 15.5, 12.3, 28.7 };
            double[] temperaturenMeetpunt2 = { 10.0, 20.2, 15.6, 12.3, 28.8, 11.1 };

            double[] doorsnede = Doorsnede(temperaturenMeetpunt1, temperaturenMeetpunt2);
            ToonDoorsnede(doorsnede);                       // toont de tekst "20,2 | 12,3"

            double[] getallen1 = { 1.23, 2.34, 3.45 };
            double[] getallen2 = { 1.99, 2.34 };
            ToonDoorsnede(Doorsnede(getallen1, getallen2)); // toont de tekst "2,34"

            double[] getallen3 = { 1.99, 2.99, 3.99 };
            ToonDoorsnede(Doorsnede(getallen1, getallen3)); // toont de tekst "geen doorsnede"


            static void ToonDoorsnede(double[] doorsnede)
            {
                if (doorsnede.Length >= 1)
                {
                    Console.WriteLine($"De doorsnede is: {string.Join(", ",doorsnede)}");

                }else { Console.WriteLine("Geen doorsnede"); }
            }

            static double[] Doorsnede(double[] getallen1, double[] getallen2)
            {
                double[] korteArray = getallen1;
                double[] langeArr = getallen2;
                if (korteArray.Length > langeArr.Length)
                {
                    korteArray = getallen2;
                    langeArr = getallen1;
                }

                // int aanmaken voor het aantal keren het doorsnijdt om de lengte van de return array te bepalen

                int doorsnede = 0;  
                for (int i = 0; i < korteArray.Length; i++)
                {
                    for (int j = 0; j < langeArr.Length; j++)
                    {
                        if (korteArray[i] == langeArr[j])
                        {
                            doorsnede++;
                        }
                    }
                }

                double[] doorsnedeArray = new double[doorsnede];

                int getal = 0;

                for(int i = 0;i < korteArray.Length; i++)
                {
                    for(int j = 0;j < langeArr.Length; j++)
                    {
                        if (korteArray[i] == langeArr[j])
                        {
                            doorsnedeArray[getal] = korteArray[i];
                            getal++;
                        }
                    }
                }

                return doorsnedeArray;
            }
        }
    }
}
