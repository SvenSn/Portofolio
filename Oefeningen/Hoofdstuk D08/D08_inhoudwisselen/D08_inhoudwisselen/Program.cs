namespace D08_inhoudwisselen
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] a = { 12, 34, 56, 78, 90 };
            int[] b = { 31, 42, 53, 64, 75 };

            Console.Write("De inhoud van a voor de wissel : ");
            Console.WriteLine(String.Join(',', a));

            // SCHRIJF HIER JE CODE OM DE ARRAY INHOUDEN OM TE WISSELEN
            int[] temp = a;
            a = b;
            b = temp;




            Console.Write("De inhoud van a na de wissel : ");
            Console.WriteLine(String.Join(',', a));
        }
    }
}
