namespace D12tonenmetformaatstring
{
    internal class Program
    {
        static void Main(string[] args)
        {
            DateTime nu = DateTime.Now; 

            string datumText = nu.ToString("dd/MM/yyyy");
            string uren = nu.ToString("HHumm");

            Console.WriteLine($"De datum vandaag is {datumText} en het is {uren}");
        }
    }
}
