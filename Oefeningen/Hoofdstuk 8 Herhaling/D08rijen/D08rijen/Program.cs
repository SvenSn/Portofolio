namespace D08rijen
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int minAantal = 3;
            double[] getallen = new double[6];

            int teller = 1;
            bool isRekenKundig = true;
            bool isMeetKundig = true;  

            for (int i = 0; i < getallen.Length; i++)
            {
                Console.WriteLine("Geef een getal in. ");
                string invoer = Console.ReadLine();

                bool isOK = double.TryParse(invoer, out double getal);
                if (isOK)
                {
                    teller++;
                    getallen[i] = getal;
                }
                

                if (invoer == "" && i >= minAantal)
                {
                    teller--;
                    break;
                }
            }

            double rekenkundig = getallen[1] - getallen[0];
            double meetkunding = getallen[1]/getallen[0];

            for (int i = 1;i < teller; i++)
            {

                if (getallen[i] - getallen[i - 1] != rekenkundig)
                {
                    isRekenKundig = false;
                }
               if (getallen[i] / getallen[i - 1] != meetkunding)
               {
                    isMeetKundig = false;
               }      
            }

            if(isMeetKundig && isRekenKundig)
            {
                Console.WriteLine("Deze rij is meetkunding en rekenkundig.");
            }
            else if (isRekenKundig && !isMeetKundig)
            {
                Console.WriteLine("Deze rij is rekenkundig.");
            }
            else if (isMeetKundig && !isRekenKundig)
            {
                Console.WriteLine("Deze rij is meetkunding.");
            }
            else if (!isMeetKundig && !isRekenKundig)
            {
                Console.WriteLine("Dit is een gewone rij. ");
            }

            
        }
    }
}
