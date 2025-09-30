namespace D08_positieszoeken
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] a = { 5, 3, 1, -1, -3, 3, 9, -4 };



            Console.WriteLine("Geef een waarde in.");
            int waarde = Int32.Parse(Console.ReadLine()); 


            for (int i = 0; i < a.Length; i++)
            {
                if(a[i] == waarde)
                {
                    waarde= a[i];
                    
                    Console.Write($"{i}");
                }
            }
        }
    }
}
