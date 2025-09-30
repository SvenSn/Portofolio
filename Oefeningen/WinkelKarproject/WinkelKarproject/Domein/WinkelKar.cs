namespace WinkelKarproject.Domein
{
    internal class WinkelKar
    {
        private List<Product> _keuzes;

        public WinkelKar()
        {
            _keuzes = new List<Product>();
        }

        public void VoegToeAanBoodschappen(Product product, int aantalstuks)
        {
            for (int i = 0;i < aantalstuks;i++)
            {
                _keuzes.Add(product);
            }
        }

        public List<string> GeefBeschrijvingPerBoodschap()
        {
            List<string> lijstje = new List<string>();

            _keuzes.Sort(new ProductenVergelijkerOpPrijs());
            foreach (Product p in _keuzes)
            {
                lijstje.Add(p.ToString());
            }

            return lijstje;
        }

        public  decimal BerekenTotalePrijsZonderKorting()
        {
            decimal totaal = 0; 
            foreach (Product p in _keuzes)
            {
                totaal += p.GeefPrijsZonderKorting();
            }
            return totaal;
        }

        public decimal BerekenTotalePrijsMetKorting()
        {
            decimal totaal = 0;
            foreach(Product p in _keuzes)
            {
                totaal += p.GeefMijPrijsMetKorting();
            }
            return totaal;  
        }
    }
}
