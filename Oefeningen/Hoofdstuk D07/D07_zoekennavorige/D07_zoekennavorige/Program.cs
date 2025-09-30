namespace D07_zoekennavorige
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
            Console.WriteLine("Geef een tekst in: ");
            string text = Console.ReadLine();

            Console.WriteLine("Geef een zoekterm in: ");
            string zoekTerm = Console.ReadLine();

            int aantalZoektermen = 0;
            // if zoland de zoekterm string niet leeg is 
            if (zoekTerm != "")
            {

               
                string textLower = text.ToLower();
                string zoekTermLower = zoekTerm.ToLower();

             
                int teller = textLower.IndexOf(zoekTermLower);

                
                while (teller != -1)
                {
                    aantalZoektermen++;
                 
                    int tellerNaZoeken = teller + (zoekTermLower.Length);

                  
                    teller = textLower.IndexOf(zoekTermLower, tellerNaZoeken);


                }



            }


            Console.WriteLine($"De zoekterm komt {aantalZoektermen} voor.");

        }
    }
}
