namespace D12frequenties
{
    internal class Program
    {
        static void Main(string[] args)
        {
            const int aantal = 10;
            int getal = 0;

            // Invoer opvangen in een array getallen:
            int[] getallen = new int[aantal];
            int som = 0;
            for (int teller = 1; teller <= aantal; teller++)
            {
                
                bool invoerOk;
                do
                {
                    Console.Write($"Getal {teller}?: ");
                    invoerOk = int.TryParse(Console.ReadLine(), out getal);
                } while (!invoerOk);
                getallen[teller - 1] = getal;
                som += getal;
            }

            Console.WriteLine();
            Console.WriteLine($"Som: {som}");
            Console.WriteLine($"Gemiddelde: {som / aantal}");

            int[] frequenties = new int[aantal];
            // In de (parallelle) frequenties array stoppen we het aantal-keer-voorkomen
            // bij het eerste voorkomen van dat getal.
            frequenties[0] = 1;
            for (int i = 1; i < getallen.Length; i++)
            {
                // Ga naar het eerste voorkomen van dat getal op positie `j`, en verhoog die frequentie.
                int j = Array.IndexOf(getallen, getal);
                frequenties[j]++;
            }

            // Afdrukken:
            Console.WriteLine("Frequenties:");
            for (int i = 0; i < getallen.Length; i++)
            {
                if (frequenties[i] > 0)
                {
                    Console.WriteLine($"  {getallen[i]} komt {frequenties[i]} voor");
                }
            }

        }
        }
    }
 

