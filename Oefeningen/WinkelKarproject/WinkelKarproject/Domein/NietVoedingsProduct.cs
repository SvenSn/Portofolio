namespace WinkelKarproject.Domein
{
    public class NietVoedingsProduct : Product
    {
        /* *Het kortingspercentage moet in het interval [0,100] liggen. 
         * Er wordt een ArgumentException metpassende foutboodschap gegooid indien het kortingspercentage niet voldoet.
         * •Bereken  voor  de  prijs  met  korting  de  korting  aan  de  hand  van  het  kortingspercentage  en  trekdeze korting af van de prijs zonder korting.
         * •Specializeer indien nodig de ToString-methodeHet kortingspercentage moet in het interval [0,100] liggen. 
         * Er wordt een ArgumentException metpassende foutboodschap gegooid indien het kortingspercentage niet voldoet.
         * •Bereken  voor  de  prijs  met  korting  de  korting  aan  de  hand  van  het  kortingspercentage  en  trekdeze korting af van de prijs zonder korting.
         * •Specializeer indien nodig de ToString-methode*/

        private int _kortingsPercentage;

        public int KortingsPercentage
        {
            get { return _kortingsPercentage; }
            set 
            {
                if (value < 0 ||  value > 100)
                {
                    throw new ArgumentException(nameof(KortingsPercentage), "Kortingspercentage moet tussen 0 en 100 liggen, grenzen inbegrepen");
                }
                _kortingsPercentage = value; 
            }
        }

        public NietVoedingsProduct(string omschrijving, decimal prijsPerStuk,int kortingPercentage): base(omschrijving, prijsPerStuk)
        {
            kortingPercentage = KortingsPercentage;
        }

        public override decimal GeefMijPrijsMetKorting()
        {
            return (GeefPrijsZonderKorting()) * (1 -(decimal)KortingsPercentage/100);
        }
        public override string ToString()
        {
            return $"{base.ToString()} en met een {KortingsPercentage} % Korting";
        }

    }
}
