namespace D18persoonopnaamslim.Domein
{
    public class PersoonNaamComparerSlim : IComparer<Persoon>
    {

        private bool _isNormaleVolgorde;

        public PersoonNaamComparerSlim(bool isNormaleVolgorde)
        {
            this._isNormaleVolgorde = isNormaleVolgorde;
        }

        public int Compare(Persoon p1,Persoon p2)
        {
            int resultaat;

            if (this._isNormaleVolgorde)
            {
                // als het normale volgorde is dus van a tot z compare persoon 1 naam met p2
                resultaat = p1.Naam.CompareTo(p2.Naam);
            }
            else
            {
             // niet normale volgorde = van z naar a 
                resultaat = p2.Naam.CompareTo(p1.Naam);
            }

            return resultaat;
        }
    }
}
