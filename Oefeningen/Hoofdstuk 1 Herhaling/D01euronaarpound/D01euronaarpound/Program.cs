namespace D01euronaarpound
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double euroBedrag = 105.4;

            double poundBedrag = euroBedrag * 0.88;

            Console.Write(euroBedrag);
            Console.Write("EUR = ");
            Console.Write(poundBedrag);
            Console.Write("GPB");
        }
    }
}
