namespace D08positieszoeken
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] a = { 5, 3, 1, -1, -3, 3, 9, -4 };


            Console.WriteLine("Geef een zoekterm in. ");
            string zoektermText = Console.ReadLine();
            int zoekterm = int.Parse(zoektermText);
            for (int i = 0; i < a.Length; i++)
            {
                if (zoekterm == a[i])
                {
                    Console.Write(i+" ");

                }

            }
        }
    }
}
