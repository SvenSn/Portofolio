namespace D08_twister
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

                int randomIndex = rnd.Next(0, 4);
                string lichaamsdeel = lichaamsdelen[randomIndex];


                randomIndex = rnd.Next(0, 4);
                string kleur = kleuren[randomIndex];



                // toon de opdracht
                Console.WriteLine($"{lichaamsdeel} op {kleur}");

                // wacht 7 seconden
                System.Threading.Thread.Sleep(7000);
            }
        }
    }
}
