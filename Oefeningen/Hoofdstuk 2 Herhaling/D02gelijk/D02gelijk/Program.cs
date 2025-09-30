namespace D02gelijk
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

            string getalCheck = "";


            if (getal1 == getal2)
            {
                getalCheck = "gelijk";
            }
            else
            {
                getalCheck = "verschillend";
            }

            Console.WriteLine($"Deze getallen zijn {getalCheck}");

        }
    }
}
