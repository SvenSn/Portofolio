using System;

namespace D08_volgordeomwisselen
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Hoeveel namen wil je in geven? ");
            int namenNummer = int.Parse(Console.ReadLine());

            string[] namen = new string[namenNummer];

            string[] namenOmgekeerd = new string[namen.Length];

            for (int i = 0; i < namenNummer; i++)
            {
                Console.Write($"Geef een naam {i + 1}. ");
                namen[i] = Console.ReadLine();

            }
           
            for (int i = 0;i < namen.Length;i++)
            {
                namenOmgekeerd[i] = namen[namen.Length -1 -i];
            }


            Console.WriteLine(string.Join(" ",namenOmgekeerd));
        }
    }
}
