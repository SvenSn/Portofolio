namespace D09dagnummernaarmaand
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] aantalDagen = { 31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 };
            string[] maandNamen = { "Januari", "Februari", "Maart", "April", "Mei", "Juni", "Juli", "Augustus", "September", "Oktober", "November", "December" };

            Console.Write("Geef dagnummer in. ");
            int dagnummer = int.Parse(Console.ReadLine());

            int som = 0;

            for (int i = 0; i < aantalDagen.Length; i++)
            {
                 som += aantalDagen[i];

                if (som == dagnummer)
                {
                    Console.Write("De maand is " + maandNamen[i]);
                }
                else if (dagnummer > 365)
                {
                    Console.WriteLine("De maand is onbepaald. ");
                    break;
                }
            }

        }
    }
}
