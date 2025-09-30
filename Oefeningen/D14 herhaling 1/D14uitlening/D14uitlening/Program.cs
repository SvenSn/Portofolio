using D14uitlening.Domein;

namespace D14uitlening
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Uitlening[] uitleningen = new Uitlening[10];
            int aantal = 0;
            do
            {
                PrintUitleningen(uitleningen, aantal);

                Console.Write("Nieuwe ontlening op?: ");
                DateTime d = DateTime.Parse(Console.ReadLine());
                Console.Write("Omschrijving?: ");
                string o = Console.ReadLine();

                aantal = Toevoegen(uitleningen, aantal, o, d);

                Console.WriteLine();
            } while (true);
        }

        static void PrintUitleningen(Uitlening[] uitleningen, int aantal)
        {
            for (int index = 0; index < aantal; index++)
            {
                Uitlening u = uitleningen[index];
                Console.WriteLine($"- {u.GetOmschrijving()}: ontleent op {u.GetOntleendatum().ToString("dd/MM/yyyy")} binnen ten laatste op {u.UitersteInleverdatum().ToString("dd/MM/yyyy")}.");
            }
            Console.WriteLine();
        }

        static int Toevoegen(Uitlening[] uitleningen, int aantal, string omschrijving, DateTime ontleendatum)
        {
            Uitlening nieuweUitlening = new Uitlening();
            nieuweUitlening.SetOmschrijving(omschrijving);
            nieuweUitlening.SetOntleendatum(ontleendatum);
            aantal++;

            uitleningen[aantal - 1] = nieuweUitlening;

            return aantal;
        }
    }
}
