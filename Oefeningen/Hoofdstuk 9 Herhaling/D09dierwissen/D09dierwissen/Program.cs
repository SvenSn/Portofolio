namespace D09dierwissen
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] boerderijDieren = { "kip", "koe", "paard", "geit", "schaap" };

            while (true)
            {
                foreach (string dier in boerderijDieren)
                {
                    if (dier == null)
                    {
                        Console.Write("GEWIST ");
                    }
                    else
                    {
                        Console.Write(dier + " ");
                    }
                }

                Console.WriteLine(string.Join(" ", boerderijDieren));
                Console.WriteLine("Welk dier wil je verwijderen");
                string invoer = Console.ReadLine().ToLower();

                int index = Array.IndexOf(boerderijDieren, invoer);

                if (index != -1)
                {
                    boerderijDieren[index]= null;
                }
            }
        }
    }
}
