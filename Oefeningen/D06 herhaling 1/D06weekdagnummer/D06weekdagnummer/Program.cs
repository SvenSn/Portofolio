namespace D06weekdagnummer
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int dagnummer;
            bool invoerOK;
            string dag = "";

            do
            {

                Console.Write("Geef een dagnummer in: ");
                invoerOK = int.TryParse(Console.ReadLine(), out dagnummer);

                if (dagnummer == 1)
                {
                    dag = "Maandag";
                }
                else if (dagnummer == 2)
                {
                    dag = "Dinsdag";
                }
                else if (dagnummer == 3)
                {
                    dag = "Woensdag";
                }
                else if (dagnummer == 4)
                {
                    dag = "Donderdag";
                }
                else if (dagnummer == 5)
                {
                    dag = "Vrijdag";
                }
                else if (dagnummer == 6)
                {
                    dag = "Zaterdag";
                }
                else if (dagnummer == 7)
                {
                    dag = "Zondag";
                }

            } while (!invoerOK || dagnummer <1 || dagnummer > 7);

            Console.WriteLine($"Dagnummer {dagnummer} is {dag}");
        }
    }
}
