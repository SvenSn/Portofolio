namespace D06_twister
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Het spel begint over 3 seconden...");


            //3 seconden delay inzettten in ms
            Thread.Sleep(3000);

            // nieuwe random maken 
            Random r = new Random();    


            //spel moet gewoon oneindig voor doen
            while (true)
            {
                int ldNummer = r.Next(0,4);
                string lichaamsDelen;


                    if (ldNummer == 0)
                {
                    lichaamsDelen = "linkerhand";
                }
                    else if (ldNummer == 1)
                {
                    lichaamsDelen = "rechterhand";
                }
                    else if (ldNummer == 2)
                {
                    lichaamsDelen = "linkervoet";
                }
                     else
                {
                    lichaamsDelen = "rechtervoet";
                }

                int kleurNummer = r.Next(0,4);
                string kleuren;

                if (kleurNummer == 0)
                {
                    kleuren = "rood";
                }
                else if (kleurNummer == 1)
                {
                    kleuren = "groen";
                }
                else if (kleurNummer == 2)
                {
                    kleuren = "blauw";
                }
                else
                {
                    kleuren = "geel";
                }

                Console.WriteLine($"{lichaamsDelen} op {kleuren}");

                Thread.Sleep(1000);

            }

        }
    }
}
