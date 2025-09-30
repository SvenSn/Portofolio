namespace D05somvanafstop
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int som = 0;
            string getaltekst;
            bool invoerOK;

            do
            {
                getaltekst = Console.ReadLine();
                invoerOK = int.TryParse(getaltekst, out int getal);
                if (invoerOK)
                {
                    som += getal;
                    Console.Write("+");

                }else if (getaltekst.ToUpper().Trim() != "STOP")
                {
                    Console.WriteLine("Gelieve een geheel getal in te voeren (of STOP om te stoppen).");
                }

            } while (getaltekst.ToUpper().Trim() != "STOP");

            Console.Write($"=\n{som}");
        }
    }
}
