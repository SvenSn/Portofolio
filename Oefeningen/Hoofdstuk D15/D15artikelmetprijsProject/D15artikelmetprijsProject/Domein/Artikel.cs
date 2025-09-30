namespace D15artikelmetprijsProject.Domein
{
    public class Artikel
    {
        private decimal _btwpercentage;

        public decimal BTWpercentage
        {
            get { return _btwpercentage; }
            set { _btwpercentage = value; }
        }

        private decimal _prijsEXBTW;

        public decimal PrijsExBTW
        {
            get { return _prijsEXBTW; }
            set { _prijsEXBTW = value; }
        }

        public Artikel(decimal prijsExBTW)
        {
            BTWpercentage = 21;
            PrijsExBTW = prijsExBTW;
        }

        public Artikel(decimal prijsExBTW, decimal bTWpercentage)
        {
            BTWpercentage = bTWpercentage;
            PrijsExBTW = prijsExBTW;
        }

        public decimal PrijsIncBTW()
        {
            return PrijsExBTW * (1 + (BTWpercentage / 100));
        }

    }
}
