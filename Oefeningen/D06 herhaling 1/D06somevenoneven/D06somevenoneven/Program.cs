namespace D06somevenoneven
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int getal;
            int tellerEven = 0;
            int tellerOdd = 0;
            int somEven = 0;
            int somOdd = 0;
            bool invoerOK;

            do
            {

                Console.Write("Geef een getal in: (negatief om te stoppen)");
                invoerOK = int.TryParse(Console.ReadLine(), out getal);
                if (invoerOK)
                {

                
                 if (getal >= 0 && getal % 2 == 0) 
                    {
                    tellerEven++;
                    somEven += getal;
                    }
                else if (getal >= 0 && getal % 2 !=0)
                {
                    tellerOdd++;
                    somOdd += getal;
                }
                }

            } while (getal >= 0 || !invoerOK);

            Console.WriteLine($"{tellerEven} even getallen.");
            Console.WriteLine($"{tellerOdd} oneven getallen.");
            Console.WriteLine($"De som van de even getallen is {somEven}");
            Console.WriteLine($"De som van de oneven getallen is {somOdd}");    
        }
    }
}
