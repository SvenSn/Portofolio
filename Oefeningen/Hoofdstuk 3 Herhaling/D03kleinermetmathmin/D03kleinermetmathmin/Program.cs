namespace D03kleinermetmathmin
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Geef een getal in. ");
            string getal1Text = Console.ReadLine();
            int getal1 = int.Parse(getal1Text);

            Console.WriteLine("Geef een getal in. ");
            string getal2Text = Console.ReadLine();
            int getal2 = int.Parse(getal2Text);


            int kleinsteGetal = Math.Min(getal1, getal2);

            Console.WriteLine($"Het kleinste getal is {kleinsteGetal}");
        }
    }
}
