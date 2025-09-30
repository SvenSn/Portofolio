namespace D05_somvanafstop
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string stop;
            bool inputOK;
            int som = 0;
            do
            {
                stop = Console.ReadLine();
                inputOK = int.TryParse(stop, out int getal);
                if (inputOK)
                {
                    som += getal;
                    Console.WriteLine("+");
                }
                else if (stop.ToUpper().Trim() != "STOP")
                {
                    Console.WriteLine("Geef een getal in of type STOP om te stoppen");

                }
            }
            while (stop.ToUpper().Trim() != "STOP");

            Console.WriteLine($"de som is {som}");
            
        }
    }
}
