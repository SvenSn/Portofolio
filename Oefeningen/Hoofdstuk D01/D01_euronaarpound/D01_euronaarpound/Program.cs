namespace D01_euronaarpound
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double euroBedrag = 105.4;
            // 1 euro = 0.88 gbp
            //euro omzetten naar pound door eurobedrag te delen door 0.88 en variabele te maken en value te geven van euro / 0.88 
            double poundBedrag = euroBedrag * 0.88;


            Console.Write(euroBedrag);
            Console.Write("EUR = ");
            Console.Write(poundBedrag);
            Console.Write("GPB");
        }
    }
}
