namespace D09_dierenwissen
{
    internal class Program
    {
        static void Main(string[] args)
        {

            string[] boerderijDieren = { "kip", "koe", "paard", "geit", "schaap" };


            do
            {
                foreach (string dieren in boerderijDieren)
                {
                    if (dieren == null)
                    {
                        Console.Write(" GEWIST ");
                    }
                    else
                    {
                        Console.Write(dieren + " ");
                    }
                }

                
                Console.WriteLine("Welk dier wil je verwijderen ");
                string dier = Console.ReadLine();

                int i = Array.IndexOf(boerderijDieren,dier);

                if (i != -1)
                {
                    boerderijDieren[i] = null;
                }



            } while (true);
        }
    }
}
