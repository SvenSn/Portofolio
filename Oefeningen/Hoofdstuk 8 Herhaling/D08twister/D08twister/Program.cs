namespace D08twister
{
    internal class Program
    {
        static void Main(string[] args)
        {


            string[] kleuren = { "rood", "groen", "blauw", "geel" };
            string[] lichaamsdelen = { "linkerhand", "rechterhand", "linkervoet", "rechtervoet" };



            Console.WriteLine("Het spel start over 3 seconden...");
            System.Threading.Thread.Sleep(3000);


            Random rnd = new Random();
            while (true)
            {
                
                int i = rnd.Next(0, 4);
                string lichaamsdeel = lichaamsdelen[i];


                i = rnd.Next(0, 4);
                string kleur = kleuren[i];
                
                
                Console.WriteLine($"{lichaamsdeel} op {kleur}");

               
                System.Threading.Thread.Sleep(7000);
            }
        }
    }
}
