namespace D08woordslang
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] woorden = new string[5];

            for (int i = 0; i < woorden.Length; i++)
            {
                Console.Write("Geef een woord in: ");
                woorden[i] = Console.ReadLine();
            }
                bool isWoordslang = true; 

                for (int j = 1; j < woorden.Length; j++)
                {
                    if (woorden[j-1][woorden[j-1].Length-1] != woorden[j][0])
                    {
                        isWoordslang = false;
                        Console.WriteLine($"Geen woordslang! Problemen bij de woorden: {woorden[j - 1]} en {woorden[j]}");
                        break;
                    }
                }

                if ((isWoordslang))
                {
                    Console.Write("Dit is een woordslang: ");
                    Console.Write(string.Join("-", woorden));
                }
            
        }
    }
}
