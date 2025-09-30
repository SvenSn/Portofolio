namespace D08dagnummer
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int dagnummer = 0;
            Console.Write("Geef een dagnummer in: ");
            bool invoerOK = int.TryParse(Console.ReadLine(), out dagnummer);

            if (invoerOK && dagnummer >= 1 && dagnummer <= 7)
            {
                string[] dagNamen = { "maandag", "dinsdag", "woensdag", "donderdag",
                          "vrijdag", "zaterdag", "zondag" };

                int index = dagnummer - 1;
                string dag = dagNamen[index];


                Console.WriteLine($"Dagnummer {dagnummer} is  {dag}");
            }
            



        }
    }
}
