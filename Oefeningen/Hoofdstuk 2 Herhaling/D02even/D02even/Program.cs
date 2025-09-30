namespace D02even
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Geef een getal in. ");
            string getalText = Console.ReadLine();
            int getal = int.Parse(getalText);

            string evenCheck = "";

            if (getal % 2 == 0)
            {
                evenCheck = "even";
            }
            else
            {
                evenCheck = "oneven";
            }


            Console.WriteLine($"het getal is {evenCheck}");
        }
    }
}
