namespace D08twister
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Het spel begint over 3 seconden...");
            System.Threading.Thread.Sleep(3000);

            Random r = new Random();    
            string[] kleuren = { "rood", "groen", "blauw", "geel" };
            string[] lichaamsdelen = { "linkerhand", "rechterhand", "linkervoet", "rechtervoet" };

            while(true)
            {
                int index = r.Next(0, 4);
                string lichaamsdeel = lichaamsdelen[index];

                index = r.Next(0, 4);

                string kleur = kleuren[index];

                Console.WriteLine($"{lichaamsdeel} op kleur {kleur}");

                System.Threading.Thread.Sleep(7000);
            }  


        }
    }
}
