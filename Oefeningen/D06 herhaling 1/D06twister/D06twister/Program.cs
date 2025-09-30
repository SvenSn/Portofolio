namespace D06twister
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Het spel start in 3 seconden...");
            System.Threading.Thread.Sleep(3000);


            do
            {
                Random r = new Random();    

                int lichaamsdeelNummmer = r.Next(0,4);
                string lichaamsdeel;

                //linkerhand, rechterhand, linkervoet, rechtervoet
                if (lichaamsdeelNummmer == 0)
                {
                    lichaamsdeel = "linkerhand";
                }
                else if (lichaamsdeelNummmer == 1)
                {
                    lichaamsdeel = "rechterhand";
                }
                else if (lichaamsdeelNummmer == 2)
                {
                    lichaamsdeel = "linkervoet";
                }
                else
                {
                    lichaamsdeel = "rechtervoet";
                }

                int kleurNummer = r.Next(0,4);
                string kleur;
                // rood, groen, blauw, geel
                if (kleurNummer == 0)
                {
                    kleur = "rood";
                }
                else if (kleurNummer == 1)
                {
                    kleur = "groen";
                }
                else if (kleurNummer == 2)
                {
                    kleur = "blauw";
                }
                else
                {
                    kleur = "geel";
                }

                Console.WriteLine($"{lichaamsdeel} op {kleur}");

                System.Threading.Thread.Sleep(7000);

            }while(true);
        }
    }
}
