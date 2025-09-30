namespace D08rijen
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int teller = 0;
            double[] getallen = new double[6];
            string invoer;


            while(teller < 6)
            {
                Console.Write("Geef een getal in: ");
                invoer = Console.ReadLine();
                

                if (string.IsNullOrEmpty(invoer)) break;

                double getal = double.Parse(invoer);

                getallen[teller] = getal;
                teller++;

            }

            bool isRekenkundig = true;

            double delta = getallen[1] - getallen[0];

            for (int i = 1; i < teller-1; i++)
            {
                if(getallen[i +1] - getallen[i] != delta )
                {
                    isRekenkundig=false;
                    break;
                }

            }

            bool isMeetkundig = true;
            double factor = getallen[1] / getallen[0];

            for (int i = 1; i < teller-1; i++)
            {
                if( getallen[i +1] /getallen[i] != factor)
                {
                    isMeetkundig = false;
                    break;
                }
            }

            if (isRekenkundig)
            {
                Console.WriteLine($"Deze getallen zijn rekenkundig met delta {delta}");
            }
            else if (isMeetkundig)
            {
                Console.WriteLine($"Deze getallen zijn meetkunding met factor {factor}");
            }else
            {
                Console.WriteLine("Dit is een gewone rij");
            }
        }
    }
}
